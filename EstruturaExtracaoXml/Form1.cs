using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EstruturaExtracaoXml
{
    public partial class Form1 : Form
    {
        private DataTable dataArquivos = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicializa a DataTable para armazenar informações sobre os arquivos
            InitializeDataTable();

            // Carrega os arquivos do diretório para a DataTable
            LoadFiles();
        }

        private void InitializeDataTable()
        {
            // Adiciona colunas à DataTable
            dataArquivos.Columns.Add("CaminhoArquivo");
            dataArquivos.Columns.Add("Situacao");
        }

        private void LoadFiles()
        {
            // Limpa os dados existentes na DataTable
            dataArquivos.Clear();

            // Obtém o caminho do diretório contendo os arquivos XML
            string caminho_raiz = Path.Combine(Environment.CurrentDirectory, "Xml");

            // Obtém os arquivos do diretório
            DirectoryInfo diretorio = new DirectoryInfo(caminho_raiz);
            FileInfo[] arquivos = diretorio.GetFiles("*.*");

            // Adiciona informações sobre os arquivos à DataTable
            foreach (FileInfo fileInfo in arquivos)
            {
                DataRow row = dataArquivos.NewRow();
                row[0] = Path.Combine(caminho_raiz, fileInfo.Name);
                row[1] = "Pendente";
                dataArquivos.Rows.Add(row);
            }

            // Exibe os dados na DataGridView
            dataGridExtracao.DataSource = dataArquivos;
        }

        private async void buttonExtract_Click(object sender, EventArgs e)
        {
            // Verifica se uma linha foi selecionada
            if (dataGridExtracao.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhuma linha selecionada.");
                return;
            }

            // Verifica se o arquivo já foi extraído
            if (dataGridExtracao.SelectedRows[0].Cells["Situacao"].Value.ToString() == "Extraido")
            {
                MessageBox.Show("Arquivo já extraído");
                return;
            }

            // Obtém o caminho do arquivo selecionado
            string caminhoDoArquivo = dataGridExtracao.SelectedRows[0].Cells["CaminhoArquivo"].Value.ToString();

            // Identifica o tipo de evento de forma assíncrona
            string tipoEvento = await Task.Run(() => IdentificarEvento(caminhoDoArquivo));

            // Se o tipo de evento foi identificado com sucesso
            if (!string.IsNullOrEmpty(tipoEvento))
            {
                // Atualiza o status do arquivo para "Extraido"
                dataGridExtracao.SelectedRows[0].Cells["Situacao"].Value = "Extraido";

                // Identifica a versão do evento de forma assíncrona
                string versao = await Task.Run(() => IdentificarVersao(caminhoDoArquivo, tipoEvento));

                // Exibe um novo formulário com informações sobre o evento
                Form2 form2 = new Form2(tipoEvento, versao);
                form2.Show();
            }
        }

        private static string IdentificarEvento(string caminhoDoArquivo)
        {
            try
            {
                // Carrega o arquivo XML usando XDocument
                XDocument xmlDoc = XDocument.Load(caminhoDoArquivo);

                // Identifica o tipo de evento
                string tipoEvento = ExtrairNomeEvento(xmlDoc.Root.ToString());
                return tipoEvento ?? "Nome do evento não encontrado";
            }
            catch (Exception ex)
            {
                return "Erro ao identificar o tipo de evento: " + ex.Message;
            }
        }

        private static string ExtrairNomeEvento(string xml)
        {
            // Extrai o nome do evento do XML
            int startIndex = xml.IndexOf("<evt") + 4;
            int endIndex = xml.IndexOf(" ", startIndex);
            if (startIndex >= 0 && endIndex > startIndex)
            {
                return xml.Substring(startIndex, endIndex - startIndex);
            }
            return null;
        }

        private static string IdentificarVersao(string caminhoDoArquivo, string tipoEvento)
        {
            try
            {
                // Carrega o arquivo XML usando XDocument
                XDocument xmlDoc = XDocument.Load(caminhoDoArquivo);

                // Identifica a versão do evento
                string versao = ExtrairVersao(xmlDoc.Root.ToString(), tipoEvento);
                return versao;
            }
            catch (Exception ex)
            {
                return "Erro ao identificar a versão do evento: " + ex.Message;
            }
        }

        private static string ExtrairVersao(string xml, string tipoEvento)
        {
            // Extrai a versão do evento do XML
            int startIndex = xml.IndexOf($"/evt/evt{tipoEvento}/v") + 10 + tipoEvento.Length;
            int endIndex = xml.IndexOf(">", startIndex) - 1;
            if (startIndex >= 0 && endIndex > startIndex)
            {
                return xml.Substring(startIndex, endIndex - startIndex);
            }
            return null;
        }
    }
}
