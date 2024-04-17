using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace EstruturaExtracaoXml
{
    
    public static class identificaEvento
    {
        public class EventoInfo
        {
            public string TipoEvento { get; set; }
            public string Versao { get; set; }
        }
        //public static string IdentificarEvento(XmlDocument xmlDoc)
        //{
        //    try
        //    {
        //        // Encontrar o nome do evento (tag que começa com '<evt' e termina com '>')
        //        string nomeEvento = ExtrairNomeEvento(xmlDoc.InnerXml);

        //        // Verificar o nome do evento
        //        if (!string.IsNullOrEmpty(nomeEvento))
        //        {
        //            return nomeEvento;
        //        }
        //        else
        //        {
        //            return "Nome do evento não encontrado";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Erro ao identificar o tipo de evento: " + ex.Message;
        //    }
        //}

        //private static string ExtrairNomeEvento(string xml)
        //{
        //    int startIndex = xml.IndexOf("<evt") + 1;
        //    int endIndex = xml.IndexOf(" ", startIndex);
        //    if (startIndex >= 0 && endIndex > startIndex)
        //    {
        //        return xml.Substring(startIndex, endIndex - startIndex);
        //    }
        //    return null;
        //}

        public static string IdentificarVersao(XDocument xmlDoc, string tipoEvento)
        {
            try
            {
                // Extrair o texto do elemento do tipo de evento
                XElement eventoElement = xmlDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == tipoEvento);
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

        private static string ExtrairVersao(string xml, string tipoEvento)
        {
            int startIndex = xml.IndexOf("/evt/" + tipoEvento + "/v") + 10 + tipoEvento.Length;
            int endIndex = xml.IndexOf(">", startIndex) - 1;
            if (startIndex >= 0 && endIndex > startIndex)
            {
                return xml.Substring(startIndex, endIndex - startIndex);
            }
            return null;
        }

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

                // Percorrer todos os elementos do documento
                foreach (var element in doc.Descendants())
                {
                    // Verificar se o nome do elemento está na lista de elementos desejados
                    if (elementosDesejados.Contains(element.Name.LocalName))
                    {
                        return element.Name.LocalName;
                    }
                }

                return "Nenhum evento encontrado";
            }
            catch (Exception ex)
            {
                // Lidar com erros de análise XML
                MessageBox.Show("Erro ao analisar XML: " + ex.Message);
                return "Erro ao analisar XML";
            }
        }

    }
}
