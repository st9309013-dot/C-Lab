using System;
using System.Text;
namespace Task5;
public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        int[][] groups = new int[][]
        {
            new int[] { 60, 75, 80, 90, 100 },
            new int[] { 50, 65, 70, 95 },
            new int[] { 90, 95, 100, 98 }
        };

        PrintGroupStatistics(groups);
    }

    public static double GetAverage(int[] marks)
    {
        int s = 0;
        foreach (int x in marks) s += x;
        return (double)s / marks.Length;
    }

    public static int GetMin(int[] marks)
    {
        int m = marks[0];
        foreach (int x in marks) if (x < m) m = x;
        return m;
    }

    public static int GetMax(int[] marks)
    {
        int m = marks[0];
        foreach (int x in marks) if (x > m) m = x;
        return m;
    }

    public static void PrintGroupStatistics(int[][] groups)
    {
        for (int i = 0; i < groups.Length; i++)
        {
            Console.WriteLine(
                $"Група {i + 1}: Середній = {GetAverage(groups[i])}, " +
                $"Мінімальний = {GetMin(groups[i])}, " +
                $"Максимальний = {GetMax(groups[i])}"
            );
        }
    }
}
