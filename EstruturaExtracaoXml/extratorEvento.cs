using System;
using System.Xml.Linq;
using System.Collections.Generic;

public static class extratorEvento
{
    public class XMLNode
    {
        public string Name { get; set; }
        public string Value { get; set; }
        // Adicione outros atributos relevantes conforme necessário
    }

    public static List<XMLNode> ExtrairXMLParaLista(XDocument xmlDoc)
    {
        List<XMLNode> nodeList = new List<XMLNode>();

        // Percorre todos os nós do XML e adiciona à lista de objetos XMLNode
        foreach (XElement element in xmlDoc.Descendants())
        {
            XMLNode node = new XMLNode();
            node.Name = element.Name.LocalName;
            node.Value = element.Value;
            // Adicione outros atributos conforme necessário
            nodeList.Add(node);
        }

        return nodeList;
    }





























    //public static void ExtrairEvento(string tipoEvento, string versaoEvento)
    //{
    //    switch (tipoEvento)
    //    {
    //        case "evtRemun":
    //            ExtrairEventoRemun(versaoEvento);
    //            break;
    //        case "evtAfastTemp":
    //            ExtrairEventoAfastTemp(versaoEvento);
    //            break;
    //        case "evtDeslig":
    //            ExtrairEventoDeslig(versaoEvento);
    //            break;
    //        case "evtTabRubr":
    //            ExtrairEventoTabRubr(versaoEvento);
    //            break;
    //        default:
    //            Console.WriteLine("Tipo de evento não reconhecido");
    //            break;
    //    }
    //}

    //private static void ExtrairEventoRemun(string versaoEvento)
    //{
    //    switch (versaoEvento)
    //    {
    //        // Implemente a extração para a versão do evento evtRemun
    //        default:
    //            Console.WriteLine("Versão do evento não reconhecida");
    //            break;
    //    }
    //}

    //private static void ExtrairEventoAfastTemp(string versaoEvento)
    //{
    //    switch (versaoEvento)
    //    {
    //        // Implemente a extração para a versão do evento evtAfastTemp
    //        default:
    //            Console.WriteLine("Versão do evento não reconhecida");
    //            break;
    //    }
    //}

    //private static void ExtrairEventoDeslig(string versaoEvento)
    //{
    //    switch (versaoEvento)
    //    {
    //        // Implemente a extração para a versão do evento evtDeslig
    //        default:
    //            Console.WriteLine("Versão do evento não reconhecida");
    //            break;
    //    }
    //}

    //private static void ExtrairEventoTabRubr(string versaoEvento)
    //{
    //    switch (versaoEvento)
    //    {
    //        // Implemente a extração para a versão do evento evtTabRubr
    //        default:
    //            Console.WriteLine("Versão do evento não reconhecida");
    //            break;
    //    }
    //}
}
