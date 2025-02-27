using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, double> faturamentoPorEstado = new Dictionary<string, double>
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

        double totalFaturamento = 0;

        foreach (var faturamento in faturamentoPorEstado.Values)
        {
            totalFaturamento += faturamento;
        }

        Console.WriteLine($"Faturamento total: R${totalFaturamento:F2}\n");

        foreach (var estado in faturamentoPorEstado)
        {
            double percentual = (estado.Value / totalFaturamento) * 100;
            Console.WriteLine($"Percentual de {estado.Key}: {percentual:F2}%");
        }

        Console.ReadLine();
    }
}
