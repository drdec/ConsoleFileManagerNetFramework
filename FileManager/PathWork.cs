using System;
using System.IO;

namespace FileManager
{
    internal class PathWork
    {
        private static string _path = Directory.GetCurrentDirectory();

        public static string GetCurrentPath()
        {
            return _path;
        }

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
