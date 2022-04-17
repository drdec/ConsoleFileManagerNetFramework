using System;
using System.IO;

namespace FileManager
{
    internal class Directories
    {
        public void PrintDirectoriesAndFiles()
        {
            Console.WriteLine("Подкаталоги");
            {
                Console.ForegroundColor = ConsoleColor.Green;
                var dirs = Directory.GetDirectories(PathWork.GetCurrentPath());

                foreach (var i in dirs)
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine();
            Console.ResetColor();

            Console.WriteLine("Файлы");
            {
                Console.ForegroundColor = ConsoleColor.Green;
                var dirs = Directory.GetFiles(PathWork.GetCurrentPath());

                foreach (var i in dirs)
                {
                    Console.WriteLine(i);
                }

                Console.ResetColor();
            }
        }

        public void DeleteDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(PathWork.GetCurrentPath());
            dir.Delete(true);
            Console.WriteLine("Каталог удален");
        }

        public void DeleteFile(string file)
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

        public void CreateCatalog()
        {

        }
    }
}
