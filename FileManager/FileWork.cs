using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace FileManager
{
    internal class FileWork
    {
        public void StartApplication()
        {
            Console.WriteLine("Введите название приложения с расширением, которое хотите запустить!");
            string name = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
            {
                Process.Start(PathWork.GetCurrentPath() + "\\" + name);
            }
        }

        public void ResizeFile(string userInput)
        {
            FileInfo file = new FileInfo(PathWork.GetCurrentPath() + "\\" + userInput);

            long size = file.Length;
            Console.WriteLine($"Размер файла - {size} байт");
            size /= 1048576;
            Console.WriteLine($"Размер файла - {size} MБ");
        }
    }
}
