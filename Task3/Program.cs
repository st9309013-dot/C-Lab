using System;
using System.Text;
namespace Task3;
public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Write("Введіть вік: ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine(ClassifyAge(a));
    }

    public static string ClassifyAge(int age)
    {
        if (age < 0 || age > 120) return "Нереальний вік";
        if (age < 12) return "Ви дитина";
        if (age <= 17) return "Підліток";
        if (age <= 59) return "Дорослий";
        return "Пенсіонер";
    }
}
