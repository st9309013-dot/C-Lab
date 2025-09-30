using System;
using System.Text;
namespace Task1;
public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Write("Введіть число: ");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine(GetMessage(x));
    }

    public static bool IsEven(int n)
    {
        return n % 2 == 0;
    }

    public static string GetMessage(int n)
    {
        if (IsEven(n))
            return "Двері відкриваються!";
        else
            return "Двері зачинені...";
    }
}
