using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EstruturaExtracaoXml
{
    public static class IdentificaEvento
    {
        // Classe para armazenar informações sobre o evento
        public class EventoInfo
        {
            public string TipoEvento { get; set; } // Tipo do evento
            public string Versao { get; set; } // Versão do evento
        }

        // Método assíncrono para identificar a versão do evento
        public static async Task<string> IdentificarVersaoAsync(XDocument xmlDoc, string tipoEvento)
        {
            try
            {
                // Extrair o texto do elemento do tipo de evento de forma assíncrona
                XElement eventoElement = await Task.Run(() => xmlDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == tipoEvento));
                if (eventoElement != null)
                {
                    string textoEvento = eventoElement.ToString();

                    // Extrair a versão do texto do evento
                    string versao = ExtrairVersao(textoEvento, tipoEvento);

                    return versao;
                }
                else
                {
                    return "Tipo de evento não encontrado: " + tipoEvento;
                }
            }
            catch (Exception ex)
            {
                return "Erro ao identificar a versão do evento: " + ex.Message;
            }
        }

        // Método privado para extrair a versão do evento a partir do XML
        private static string ExtrairVersao(string xml, string tipoEvento)
        {
            // Localiza o índice inicial e final da versão no XML
            int startIndex = xml.IndexOf("/evt/" + tipoEvento + "/v") + 7 + tipoEvento.Length;
            int endIndex = xml.IndexOf(">", startIndex) - 1;

            // Verifica se os índices são válidos
            if (startIndex >= 0 && endIndex > startIndex)
            {
                // Extrai a substring que contém a versão
                string versaoSubstring = xml.Substring(startIndex, endIndex - startIndex);

                // Aplica a formatação necessária à versão (seguindo o padrão desejado)
                string versaoFormatada = FormatarVersao(versaoSubstring);

                // Retorna a versão formatada
                return versaoFormatada;
            }
            return null;
        }

        // Método para formatar a versão conforme o padrão desejado
        private static string FormatarVersao(string versao)
        {
            // Verifica se a string de entrada está vazia
            if (string.IsNullOrWhiteSpace(versao))
            {
                throw new ArgumentException("A string de entrada está vazia.");
            }

            // Remove tudo do início da string até encontrar um número inteiro não nulo
            string numberPattern = @"\d+";
            Match match = Regex.Match(versao, numberPattern);
            if (match.Success)
            {
                versao = versao.Substring(match.Index);
            }
            else
            {
                throw new ArgumentException("A string de entrada não contém um número inteiro não nulo.");
            }

            // Substitui todos os "_" por "."
            versao = versao.Replace("_", ".");

            return versao;
        }

        // Método para obter o nome do evento a partir do documento XML
        public static string ObterNomeEvento(XDocument doc)
        {
            try
            {
                // Verificar se o documento XML não é nulo
                if (doc == null)
                {
                    return "Documento XML nulo";
                }

                // Definir os nomes dos elementos desejados
                string[] elementosDesejados = { "evtDeslig", "evtTabRubrica", "evtPgtos", "evtRemun" };

                // Percorrer todos os elementos do documento de forma assíncrona
                var nomeEvento = Task.Run(() =>
                {
                    foreach (var element in doc.Descendants())
                    {
                        // Verificar se o nome do elemento está na lista de elementos desejados
                        if (elementosDesejados.Contains(element.Name.LocalName))
                        {
                            return element.Name.LocalName;
                        }
                    }
                    return "Nenhum evento encontrado";
                });

                return nomeEvento.Result;
            }
            catch (Exception ex)
            {
                // Lidar com erros de análise XML
                return "Erro ao analisar XML: " + ex.Message;
            }
        }

        // Método assíncrono para obter os nomes desejados por evento
        public static async Task<List<string>> NomesDesejadosPorEventoAsync(EventoInfo eventInfo)
        {
            // Criar lista de nomes vazia
            List<string> nomesDesejados = new List<string>();

            // Obter nomes específicos para cada tipo de evento
            switch (eventInfo.TipoEvento)
            {
                case "evtPgtos":
                    nomesDesejados.AddRange(new List<string> { "ideEvento", "cpfBenef", "nrRecibo" }); //Nós para exemplificar
                    break;
                case "evtDeslig":
                    nomesDesejados.AddRange(new List<string> { "ideEvento", "ideVinculo", "cpfTrab" }); 
                    break;
                case "evtTabRubrica":
                    nomesDesejados.AddRange(new List<string> { "ideEvento", "dhRecepcao", "nrRecibo" });
                    break;
                case "evtRemun":
                    nomesDesejados.AddRange(new List<string> { "ideEvento", "cpfTrab", "codRubr" });
                    break;
                default:
                    // Se o tipo de evento não for reconhecido, retorna null
                    return null;
            }
            // Retornar a lista de nomes assincronamente
            return nomesDesejados;

        }
    }
}
