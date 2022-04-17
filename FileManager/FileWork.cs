using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace FileManager
{
    internal class FileWork
    {
        /// <summary>
        /// запускает приложение
        /// </summary>
        public void StartApplication()
        {
            Console.WriteLine("Введите название приложения с расширением, которое хотите запустить!");
            string name = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
            {
                Process.Start(PathWork.GetCurrentPath() + "\\" + name);
            }
        }

        /// <summary>
        /// Выводит информацию о размере файла
        /// </summary>
        /// <param name="userInput">название файла</param>
        public void ResizeFile(string userInput)
        {
            FileInfo file = new FileInfo(PathWork.GetCurrentPath() + "\\" + userInput);

            long size = file.Length;
            Console.WriteLine($"Размер файла - {size} байт");
            size /= 1048576;
            Console.WriteLine($"Размер файла - {size} MБ");
        }

        /// <summary>
        /// удаляет выбранный файл
        /// </summary>
        /// <param name="file">имя файла с расширением</param>
        public void DeleteFile(string file)
        {
            Console.WriteLine("Если вы уверены, что хотите удалить файл, введите \"да\"\n" +
                              "В противном случае нажмите Enter");
            string proof = Console.ReadLine();
            if (proof == "да")
            {
                string path = PathWork.GetCurrentPath();

                if (!path.EndsWith("\\"))
                {
                    path += "\\";
                }

                path += file;

                File.Delete(path);
                Console.WriteLine("Файл удален");
            }
        }

    }
}
