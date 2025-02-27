using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

class Program
{
    static void Main()
    {
        int indice = 13;
        int soma = 0;
        int k = 0;

        while (k < indice)
        {
            k++;
            soma = soma + k;
        }

        //com indice 13 a resposta será 91
        Console.WriteLine($"Soma: {soma}");
    }
}