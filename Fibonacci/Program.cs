using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Digite um número para verificar se pertence à sequência de Fibonacci (ou pressione Enter para sair): ");
            string entrada = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entrada))
                break;

            if (int.TryParse(entrada, out int numero))
                Console.WriteLine($"O número {numero} {(EhFibonacci(numero) ? "pertence" : "NÃO pertence")} à sequência de Fibonacci.");
            else
                Console.WriteLine("Por favor, digite um número válido.");
        }

        Console.WriteLine("Programa encerrado.");
    }

    static bool EhFibonacci(int num)
    {
        int a = 0, b = 1, temp;

        while (a <= num)
        {
            if (a == num)
                return true;

            temp = a + b;
            a = b;
            b = temp;
        }

        return false;
    }
}
