using System;
using System.Text;
namespace Task2;
public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        int[] arr = GenerateRandomArray(10, 1, 100);
        Console.WriteLine("Масив: " + string.Join(" ", arr));
        Console.WriteLine("Сума: " + GetSum(arr));
        Console.WriteLine("Середнє: " + GetAverage(arr));
        Console.WriteLine("Мінімум: " + GetMin(arr));
        Console.WriteLine("Максимум: " + GetMax(arr));
    }

    public static int[] GenerateRandomArray(int size, int min, int max)
    {
        Random r = new Random();
        int[] a = new int[size];
        for (int i = 0; i < size; i++)
            a[i] = r.Next(min, max + 1);
        return a;
    }

    public static int GetSum(int[] numbers)
    {
        int s = 0;
        foreach (int x in numbers) s += x;
        return s;
    }

    public static double GetAverage(int[] numbers)
    {
        return (double)GetSum(numbers) / numbers.Length;
    }

    public static int GetMin(int[] numbers)
    {
        int m = numbers[0];
        foreach (int x in numbers) if (x < m) m = x;
        return m;
    }

    public static int GetMax(int[] numbers)
    {
        int m = numbers[0];
        foreach (int x in numbers) if (x > m) m = x;
        return m;
    }
}
