using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string nome = "Ayrton Senna";
        string nomeInvertido = "";

        for (int i = nome.Length - 1; i >= 0; i--)
        {
            nomeInvertido += nome[i];
        }

        Console.WriteLine($"Strig original: {nome}");
        Console.WriteLine($"String invertida: {nomeInvertido}");
    }
}