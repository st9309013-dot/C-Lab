using System;
using System.IO;

namespace Modul_task1
{
    public delegate string TextOperation(string input);

    class Program
    {
        static void Main(string[] args)
        {
            string projectDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            string inputFile = Path.Combine(projectDir, "text24.txt");
            string outputFile = Path.Combine(projectDir, "result24.txt");

            if (!File.Exists(inputFile) || File.ReadAllText(inputFile).Trim() == "")
            {
                File.WriteAllText(inputFile, "Привіт! Це мій тестовий файл для завдання.\nПрограмування на C# - це дуже цікаво.\nНомер групи 24.");
            }

            File.WriteAllText(outputFile, "");

            ProcessFile(inputFile, outputFile, ToUpperCase, "--- ВЕРХНІЙ РЕГІСТР ---");
            ProcessFile(inputFile, outputFile, CountChars, "--- КІЛЬКІСТЬ СИМВОЛІВ ---");
            ProcessFile(inputFile, outputFile, CountWords, "--- КІЛЬКІСТЬ СЛІВ ---");
        }

        static string ToUpperCase(string input) => input.ToUpper();

        static string CountChars(string input) => input.Length.ToString();

        static string CountWords(string input) =>
            input.Split(new[] { ' ', '\t', '-', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length.ToString();

        static void ProcessFile(string inputPath, string outputPath, TextOperation operation, string header)
        {
            if (!File.Exists(inputPath)) return;

            string[] lines = File.ReadAllLines(inputPath);

            using (StreamWriter sw = File.AppendText(outputPath))
            {
                sw.WriteLine(header);
                foreach (var line in lines)
                {
                    sw.WriteLine(operation(line));
                }
                sw.WriteLine();
            }
        }
    }
}