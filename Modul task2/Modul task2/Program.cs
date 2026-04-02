using System;
using System.IO;

namespace Modul_task2
{
    public class MessagePublisher
    {
        public event Action<string> MessageSent;

        public void Send(string message)
        {
            MessageSent?.Invoke(message);
        }
    }

    public class FileLogger
    {
        private readonly string _logFilePath;

        public FileLogger(string logFilePath, MessagePublisher publisher)
        {
            _logFilePath = logFilePath;
            publisher.MessageSent += LogToFile;
        }

        private void LogToFile(string message)
        {
            string logEntry = $"[{DateTime.Now:HH:mm:ss}] {message}\n";
            File.AppendAllText(_logFilePath, logEntry);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string projectDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            string logFile = Path.Combine(projectDir, "log24.txt");

            MessagePublisher publisher = new MessagePublisher();
            FileLogger logger = new FileLogger(logFile, publisher);

            for (int i = 0; i < 4; i++)
            {
                Console.Write("Введіть текст: ");
                string input = Console.ReadLine();
                publisher.Send(input);
            }
        }
    }
}