using System.Data;
using System.Xml;

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
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(caminhoDoArquivo);

                string tipoEvento = IdentificarEvento(xmlDoc);

                if (tipoEvento != "")
                {
                    dataGridExtracao.SelectedRows[0].Cells["Situacao"].Value = "Extraido";
                    string versao = IdentificarVersao(xmlDoc, tipoEvento);
                    Form2 form2 = new Form2(tipoEvento, versao);
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
        static string IdentificarEvento(XmlDocument xmlDoc)
        {
            try
            {
                // Encontrar o nome do evento (tag que começa com '<evt' e termina com '>')
                string nomeEvento = ExtrairNomeEvento(xmlDoc.InnerXml);

                // Verificar o nome do evento
                if (!string.IsNullOrEmpty(nomeEvento))
                {
                    return nomeEvento;
                }
                else
                {
                    return "Nome do evento não encontrado";
                }
            }
            catch (Exception ex)
            {
                return "Erro ao identificar o tipo de evento: " + ex.Message;
            }
        }

        static string ExtrairNomeEvento(string xml)
        {
            int startIndex = xml.IndexOf("<evt") + 4;
            int endIndex = xml.IndexOf(" ", startIndex);
            if (startIndex >= 0 && endIndex > startIndex)
            {
                return xml.Substring(startIndex, endIndex - startIndex);
            }
            return null;
        }

        static string IdentificarVersao(XmlDocument xmlDoc, string tipoEvento)
        {
            try
            { 
                // Obter o elemento "evento"
                XmlNode eventoNode = xmlDoc.DocumentElement;

                // Extrair o texto da linha
                string textoEvento = eventoNode.InnerXml;
                string Versao = ExtrairVersao(xmlDoc.InnerXml,tipoEvento);
                return Versao;                

                /* if (eSocialNode != null)
                {
                    return "Versão do evento : " + versaoEvento;
                }
                else
                {
                    return "Elemento eSocial não encontrado para o evento ";
                }*/
            }
            catch (Exception ex)
            {
                return "Erro ao identificar a versão do evento : " + ex.Message;
            }
            return string.Empty;
        }

        static string ExtrairVersao(string xml, string tipoEvento)
        {
            int startIndex = xml.IndexOf("/evt/evt" + tipoEvento +"/v") + 10 + tipoEvento.Length ;
            int endIndex = xml.IndexOf(">", startIndex) - 1;
            if (startIndex >= 0 && endIndex > startIndex)
            {
                return xml.Substring(startIndex, endIndex - startIndex);
            }
            return null;
        }
    }
}