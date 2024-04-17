using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;

namespace EstruturaExtracaoXml
{
    public partial class Form1 : Form
    {
        DataTable dataArquivos = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            dataArquivos.Columns.Add("CaminhoArquivo");
            dataArquivos.Columns.Add("Situacao");

            dataArquivos.Clear();

            string caminho_raiz = Path.Combine(Environment.CurrentDirectory, "Xml");

            DirectoryInfo diretorio = new DirectoryInfo(caminho_raiz);
            FileInfo[] Arquivos = diretorio.GetFiles("*.*");

            foreach (FileInfo fileinfo in Arquivos)
            {
                DataRow colunaArquivo = dataArquivos.NewRow();
                colunaArquivo[0] = Path.Combine(caminho_raiz, fileinfo.Name);
                colunaArquivo[1] = "Pendente";
                dataArquivos.Rows.Add(colunaArquivo);
            }

            dataGridExtracao.DataSource = dataArquivos;
        }

        private void buttonExtract_Click(object sender, EventArgs e)
        {

            if (dataGridExtracao.SelectedRows.Count > 0 && dataGridExtracao.SelectedRows[0].Cells["Situacao"].Value.ToString() != "Extraido")
            {
                string caminhoDoArquivo = "";
                caminhoDoArquivo = dataGridExtracao.SelectedRows[0].Cells["CaminhoArquivo"].Value.ToString();

                // Carregar o XML
                XDocument xDoc = new XDocument();
                xDoc = XDocument.Load(caminhoDoArquivo);

                //istânciar a classe EventoInfo
                identificaEvento.EventoInfo eventoInfo = new identificaEvento.EventoInfo();

                eventoInfo.TipoEvento = identificaEvento.ObterNomeEvento(xDoc);

                if (eventoInfo.TipoEvento != "")
                {
                    dataGridExtracao.SelectedRows[0].Cells["Situacao"].Value = "Extraido";
                    eventoInfo.Versao = identificaEvento.IdentificarVersao(xDoc,eventoInfo.TipoEvento);
                    extratorEvento.XMLNode xmlNode = new extratorEvento.XMLNode();
                    List<extratorEvento.XMLNode> nodeList = extratorEvento.ExtrairXMLParaLista(xDoc);



                    Form2 form2 = new Form2(eventoInfo);
                    form2.Show();
                }
            }
            else
            {
                if (dataGridExtracao.SelectedRows[0].Cells["Situacao"].Value.ToString() == "Extraido")
                {
                    MessageBox.Show("Arquivo já extraido");
                }
                MessageBox.Show("Nenhuma linha selecionada.");
            }
        }
    }
}