using System.Collections.Generic;
using System.Linq;
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
        }

        // Método para extrair o conteúdo do XML para uma lista de objetos XMLNode
        public static async IAsyncEnumerable<XMLNode> ExtrairXMLParaListaAsync(XElement xmlElement)
        {
            await Task.Yield(); // Simula uma operação assíncrona

            // Itera sobre todos os elementos descendentes do elemento XML fornecido
            foreach (var element in xmlElement.Descendants())
            {
                // Cria um objeto XMLNode para armazenar o nome e o valor do elemento
                yield return new XMLNode
                {
                    Name = element.Name.LocalName, // Obtém o nome local do elemento
                    Value = element.Value // Obtém o valor do elemento
                    // Outros atributos podem ser adicionados conforme necessário
                };
            }
        }

        // Método para filtrar os nós XML por nome
        public static IEnumerable<XMLNode> FiltrarPorNomeDoNo(IEnumerable<XMLNode> lista, string nome)
        {
            // Filtra os nós da lista com o nome fornecido
            return lista.Where(item => item.Name == nome);
        }

        // Método para encontrar e remover o primeiro elemento com o nome especificado
        public static XMLNode ExtrairERemoverPrimeroElemento(List<XMLNode> nodes, string elementName)
        {
            // Encontra o primeiro elemento com o nome especificado na lista de nós
            var primeiroElemento = nodes.FirstOrDefault(x => x.Name == elementName);

            // Se o elemento for encontrado, remove-o da lista
            if (primeiroElemento != null)
                nodes.Remove(primeiroElemento);
            // Retorna o primeiro elemento encontrado (ou null se não encontrado)
            return primeiroElemento;
        }
    }
}

            
            
     