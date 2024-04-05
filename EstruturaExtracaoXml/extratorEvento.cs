using System;

public static class extratorEvento
{
    public static void ExtrairEvento(string tipoEvento, string versaoEvento)
    {
        switch (tipoEvento)
        {
            case "evtRemun":
                ExtrairEventoRemun(versaoEvento);
                break;
            case "evtAfastTemp":
                ExtrairEventoAfastTemp(versaoEvento);
                break;
            case "evtDeslig":
                ExtrairEventoDeslig(versaoEvento);
                break;
            case "evtTabRubr":
                ExtrairEventoTabRubr(versaoEvento);
                break;
            default:
                Console.WriteLine("Tipo de evento não reconhecido");
                break;
        }
    }

    private static void ExtrairEventoRemun(string versaoEvento)
    {
        switch (versaoEvento)
        {
            // Implemente a extração para a versão do evento evtRemun
            default:
                Console.WriteLine("Versão do evento não reconhecida");
                break;
        }
    }

    private static void ExtrairEventoAfastTemp(string versaoEvento)
    {
        switch (versaoEvento)
        {
            // Implemente a extração para a versão do evento evtAfastTemp
            default:
                Console.WriteLine("Versão do evento não reconhecida");
                break;
        }
    }

    private static void ExtrairEventoDeslig(string versaoEvento)
    {
        switch (versaoEvento)
        {
            // Implemente a extração para a versão do evento evtDeslig
            default:
                Console.WriteLine("Versão do evento não reconhecida");
                break;
        }
    }

    private static void ExtrairEventoTabRubr(string versaoEvento)
    {
        switch (versaoEvento)
        {
            // Implemente a extração para a versão do evento evtTabRubr
            default:
                Console.WriteLine("Versão do evento não reconhecida");
                break;
        }
    }
}
