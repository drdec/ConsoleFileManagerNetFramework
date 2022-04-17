using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManager
{
    internal class Directories
    {
        private readonly PathWork Path;
        private List<string> _listWithFileAndCatalogName;

        public Directories()
        {
            Path = new PathWork();
            _listWithFileAndCatalogName = new List<string>();
        }

        /// <summary>
        /// Вывод на экран консоли информации о нахождении в папке
        /// файлов и каталогов
        /// </summary>
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

        /// <summary>
        /// удаляет директорию вместе с внутренними файлами
        /// </summary>
        public void DeleteDirectory()
        {
            Console.WriteLine("Если вы уверены, что хотите удалить каталог, введите \"да\"\n" +
                              "В противном случае нажмите Enter");
            string proof = Console.ReadLine();
            if (proof == "да")
            {
                DirectoryInfo dir = new DirectoryInfo(PathWork.GetCurrentPath());
                dir.Delete(true);
                Console.WriteLine("Каталог удален");
                Path.BackToLastCatalog();
            }
        }


        /// <summary>
        /// Создает новый каталог
        /// </summary>
        public void CreateCatalog()
        {
            Console.WriteLine("Введите название создаваемого каталога!");
            string catalogName = Console.ReadLine();

            Directory.CreateDirectory(PathWork.GetCurrentPath() + "\\" + catalogName);
        }


        /// <summary>
        /// Перемещает каталог по новому пути!
        /// </summary>
        public void MoveCatalog()
        {
            Console.WriteLine("укажите путь, куда должен быть перемещен каталог");
            string catalogPath = Console.ReadLine();

            if (!string.IsNullOrEmpty(catalogPath))
            {
                Directory.Move(PathWork.GetCurrentPath(), catalogPath);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("путь не должен быть пустым!!!");
                Console.ResetColor();
            }

            Path.BackToLastCatalog();
        }

        /// <summary>
        /// Переименовывает каталог, в котором вы находитесь
        /// </summary>
        public void Rename()
        {
            Console.WriteLine("Укажите новое название каталога");
            string name = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
            {
                string newPath = Path.BackToLastCatalog(PathWork.GetCurrentPath());
                Directory.Move(PathWork.GetCurrentPath(), newPath + "\\" + name);
                Console.WriteLine("каталог успешно переименован!");
                Path.BackToLastCatalog();
            }
        }

        /// <summary>
        /// Выводить информацию о размере каталога
        /// </summary>
        public void ResizeCatalog()
        {
            long dirSize = SafeEnumerateFiles(PathWork.GetCurrentPath(), "*.*", SearchOption.AllDirectories)
                .Sum(n => new FileInfo(n).Length);
            
            Console.WriteLine($"Размер файла - {dirSize} байт");
            double size = (double)dirSize / 1048576;
            Console.WriteLine($"Размер файла - {size} MБ");
        }

        public void SearchFileAndCatalog(string name)
        {
            SearchFileAndCatalog(name, PathWork.GetCurrentPath());

            foreach (var i in _listWithFileAndCatalogName)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Поиск файлов и каталогов, где имеется совпадение с данной подстрокой
        /// </summary>
        /// <param name="name">имя файла</param>
        /// <param name="path">путь</param>
        private void SearchFileAndCatalog(string name, string path)
        {
            var dirsCat = Directory.GetDirectories(path);

            foreach (var i in dirsCat)
            {
                if (i.Contains(name))
                {
                    _listWithFileAndCatalogName.Add(i);
                }

                SearchFileAndCatalog(name, i);
            }

            var dirsFiles = Directory.GetFiles(path);

            foreach (var i in dirsFiles)
            {
                if (i.Contains(name))
                {
                    _listWithFileAndCatalogName.Add(i);
                }
            }

        }

        private static IEnumerable<string> SafeEnumerateFiles(string path, string searchPattern = "*.*",
            SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            var dirs = new Stack<string>();
            dirs.Push(path);

            while (dirs.Count > 0)
            {
                string currentDirPath = dirs.Pop();
                if (searchOption == SearchOption.AllDirectories)
                {
                    try
                    {
                        string[] subDirs = Directory.GetDirectories(currentDirPath);
                        foreach (string subDirPath in subDirs)
                        {
                            dirs.Push(subDirPath);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        continue;
                    }
                    catch (DirectoryNotFoundException)
                    {
                        continue;
                    }
                }

                string[] files = null;
                try
                {
                    files = Directory.GetFiles(currentDirPath, searchPattern);
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (DirectoryNotFoundException)
                {
                    continue;
                }

                foreach (string filePath in files)
                {
                    yield return filePath;
                }
            }
        }
    }
}
