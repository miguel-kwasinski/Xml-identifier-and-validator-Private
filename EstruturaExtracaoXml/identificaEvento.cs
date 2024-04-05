using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EstruturaExtracaoXml
{
    
    public static class identificaEvento
    {
        public class EventoInfo
        {
            public string TipoEvento { get; set; }
            public string Versao { get; set; }
        }
        public static string IdentificarEvento(XmlDocument xmlDoc)
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

        private static string ExtrairNomeEvento(string xml)
        {
            int startIndex = xml.IndexOf("<evt") + 1;
            int endIndex = xml.IndexOf(" ", startIndex);
            if (startIndex >= 0 && endIndex > startIndex)
            {
                return xml.Substring(startIndex, endIndex - startIndex);
            }
            return null;
        }

        public static string IdentificarVersao(XmlDocument xmlDoc, string tipoEvento)
        {
            try
            {
                // Obter o elemento "evento"
                XmlNode eventoNode = xmlDoc.DocumentElement;

                // Extrair o texto da linha
                string textoEvento = eventoNode.InnerXml;
                string Versao = ExtrairVersao(xmlDoc.InnerXml, tipoEvento);
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
    }
}
