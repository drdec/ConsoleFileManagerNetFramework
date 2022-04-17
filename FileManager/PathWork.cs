using System;
using System.IO;

namespace FileManager
{
    internal class PathWork
    {
        private static string _path = Directory.GetCurrentDirectory();

        /// <summary>
        /// Возвращает текущее местоположение
        /// </summary>
        /// <returns>путь</returns>
        public static string GetCurrentPath()
        {
            return _path;
        }
        
        /// <summary>
        /// Возвращается на уровень выше в каталоге
        /// Если выше идти некуда, то путь остается неизменным
        /// </summary>
        public void BackToLastCatalog()
        {
            for (int i = _path.Length - 1, j = 0; i >= 0; i--, j++)
            {
                if (_path[i] == '\\')
                {
                    _path = _path.Remove(_path.Length - j - 1);
                    break;
                }
            }

            if (_path.EndsWith(":"))
            {
                _path += "\\";
            }
        }

        /// <summary>
        /// Возвращает путь на папку выше
        /// Данный метод НИКАК не влияет на текущее нахождение в папке или каталоге
        /// </summary>
        /// <param name="path">путь</param>
        /// <returns>путь</returns>
        public string BackToLastCatalog(string path)
        {
            for (int i = path.Length - 1, j = 0; i >= 0; i--, j++)
            {
                if (path[i] == '\\')
                {
                    path = _path.Remove(_path.Length - j - 1);
                    break;
                }
            }

            if (path.EndsWith(":"))
            {
                path += "\\";
            }

            return path;
        }

        /// <summary>
        /// переход по указанному пути
        /// </summary>
        /// <param name="path">путь</param>
        /// <exception cref="DirectoryNotFoundException">неверный путь к директории</exception>
        public void SwitchToDirectory(string path)
        {
            if (!_path.EndsWith("\\"))
            {
                _path += "\\";
            }

            if (Directory.Exists(path))
            {
                _path = path;
            }
            else if (Directory.Exists(_path + path))
            {
                _path += path;
            }
            else
            {
                _path = _path.Remove(_path.Length - 1);
                throw new DirectoryNotFoundException("Директория не найдена");
            }
        }
    }
}
