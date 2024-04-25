using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace EstruturaExtracaoXml
{
    public partial class Form1 : Form
    {
        private DataTable dataArquivos = new DataTable();

        public Form1()
        {
            InitializeComponent();
            InicializarDataTable();
        }

        private void InicializarDataTable()
        {
            dataArquivos.Columns.Add("CaminhoArquivo");
            dataArquivos.Columns.Add("Situacao");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

        private async void buttonExtract_Click(object sender, EventArgs e)
        {
            if (dataGridExtracao.SelectedRows.Count > 0 && dataGridExtracao.SelectedRows[0].Cells["Situacao"].Value.ToString() != "Extraido")
            {
                string caminhoDoArquivo = dataGridExtracao.SelectedRows[0].Cells["CaminhoArquivo"].Value.ToString();
                await ExtrairInformacoesXMLAsync(caminhoDoArquivo);
            }
            else
            {
                if (dataGridExtracao.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Nenhuma linha selecionada.");
                }
                else
                {
                    MessageBox.Show("Arquivo já extraído");
                }
            }
        }

        private async Task ExtrairInformacoesXMLAsync(string caminhoDoArquivo)
        {
            try
            {
                XDocument xDoc = XDocument.Load(caminhoDoArquivo);
                string tipoEvento = await Task.Run(() => IdentificaEvento.ObterNomeEvento(xDoc));

                if (!string.IsNullOrEmpty(tipoEvento))
                {
                    dataGridExtracao.SelectedRows[0].Cells["Situacao"].Value = "Extraido";
                    string versao = await IdentificaEvento.IdentificarVersaoAsync(xDoc, tipoEvento);

                    // Chama o método ExtrairXMLParaLista para obter os nós XML
                    List<ExtratorEvento.XMLNode> nodeList = await ExtratorEvento.ExtrairXMLParaListaAsync(xDoc.Root).ToListAsync();

                    // Chama o método FiltrarPorNomeDoNo para filtrar os nós pelo nome
                    string nomeParaFiltrar = "detVerbas"; // Substitua "NomeDesejado" pelo nome desejado
                    List<ExtratorEvento.XMLNode> nodeListFiltrados = ExtratorEvento.FiltrarPorNomeDoNo(nodeList, nomeParaFiltrar).ToList();

                    string nomeParaExtrair = "detVerbas";
                    ExtratorEvento.XMLNode retorno = new ExtratorEvento.XMLNode();
                    do
                    {
                        retorno = ExtratorEvento.ExtrairERemoverPrimeroElemento(nodeList, nomeParaExtrair);
                    } while (retorno != null);
                    string ForStop;
  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao extrair informações do arquivo: {ex.Message}");
            }
        }
    }
}
