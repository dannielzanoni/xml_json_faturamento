using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        string xmlPath = "faturamento_mensal/dados.xml";

        List<Dados> dadosFaturamento = LerXml(xmlPath);

        if (dadosFaturamento.Count > 0)
        {
            Console.WriteLine("Dados de Faturamento Mensal (XML)");

            var dadosComFaturamento = dadosFaturamento
                .Where(d => d.Valor > 0 && !(d.Dia % 7 == 6 || d.Dia % 7 == 0))
                .ToList();

            var menorFaturamento = dadosComFaturamento.Min(d => d.Valor);
            var diaMenorFaturamento = dadosComFaturamento.FirstOrDefault(d => d.Valor == menorFaturamento)?.Dia;
            var diaDaSemanaMenorFaturamento = ObterDiaDaSemana(diaMenorFaturamento.Value);

            var maiorFaturamento = dadosComFaturamento.Max(d => d.Valor);
            var diaMaiorFaturamento = dadosComFaturamento.FirstOrDefault(d => d.Valor == maiorFaturamento)?.Dia;
            var diaDaSemanaMaiorFaturamento = ObterDiaDaSemana(diaMaiorFaturamento.Value);

            var mediaFaturamento = dadosComFaturamento.Average(d => d.Valor);
            var diasAcimaMedia = dadosComFaturamento.Count(d => d.Valor > mediaFaturamento);

            Console.WriteLine($"Menor valor de faturamento: {menorFaturamento:C2}, no dia: {diaMenorFaturamento}, {diaDaSemanaMenorFaturamento}");
            Console.WriteLine($"Maior valor de faturamento: {maiorFaturamento:C2}, no dia: {diaMaiorFaturamento}, {diaDaSemanaMaiorFaturamento}");
            Console.WriteLine($"Número de dias com faturamento superior à média mensal: {diasAcimaMedia}");
        }
        else
        {
            Console.WriteLine("Não foram encontrados dados de faturamento.");
        }

        Console.ReadLine();
    }

    static List<Dados> LerXml(string caminho)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Root));
        string content = File.ReadAllText(caminho);

        //xml veio sem raiz
        if (!content.StartsWith("<root>"))
        {
            content = "<root>" + content + "</root>";
        }

        using StringReader stringReader = new StringReader(content);
        Root root = (Root)serializer.Deserialize(stringReader);
        return root.Dados ?? new List<Dados>();
    }
    static string ObterDiaDaSemana(int dia)
    {
        //dia 1 = segunda-feira
        var diasDaSemana = new[] { "Segunda-feira", "Terça-feira", "Quarta-feira", "Quinta-feira", "Sexta-feira", "Sábado", "Domingo" };
        return diasDaSemana[(dia - 1) % 7];
    }
}

[XmlRoot("root")]
public class Root
{
    [XmlElement("row")]
    public List<Dados>? Dados { get; set; }
}

public class Dados
{
    [XmlElement("dia")]  
    public int Dia { get; set; }

    [XmlElement("valor")]  
    public double Valor { get; set; }
}