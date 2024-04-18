using System.Collections.Generic;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace EstruturaExtracaoXml
{
    public static class ExtratorEvento
    {
        // Classe para representar um nó XML
        public class XMLNode
        {
            public string Name { get; set; } // Nome do elemento XML
            public string Value { get; set; } // Valor do elemento XML
                                              // Você pode adicionar outros atributos relevantes conforme necessário
        }

        // Método para extrair o conteúdo do XML para uma lista de objetos XMLNode
        public static async IAsyncEnumerable<XMLNode> ExtrairXMLParaListaAsync(XElement xmlElement)
        {
            await Task.Yield(); // Simula uma operação assíncrona

            foreach (var element in xmlElement.Descendants())
            {
                yield return new XMLNode
                {
                    Name = element.Name.LocalName,
                    Value = element.Value
                    // Adicione outros atributos conforme necessário
                };
            }
        }
    }
}
