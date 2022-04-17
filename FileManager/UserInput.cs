using System;
using System.IO;

namespace FileManager
{
    public class UserInput
    {
        private string _path;
        private readonly PathWork _pathWork;
        private readonly Directories _directories;

        public UserInput()
        {
            _pathWork = new PathWork();
            _directories = new Directories();
        }

        public void Input(string str)
        {
            string result = ParseCommand(str);

            switch (result)
            {
                case "cd":
                {
                    _pathWork.SwitchToDirectory(_path);
                }
                    break;

                case "path":
                {
                    _pathWork.SwitchToDirectory(_path);
                }
                    break;

                case "\\":
                {
                    _pathWork.BackToLastCatalog();
                }
                    break;

                case "deldir":
                {
                      _directories.DeleteDirectory();  
                }
                    break;

                case "delfile":
                {
                    _directories.DeleteFile(_path);
                }
                    break;

                case "info":
                {
                    _directories.PrintDirectoriesAndFiles();
                }
                    break;

                case "copy":
                {

                }
                    break;

                case "create":
                {

                }
                    break;

                case "rename":
                {

                }
                    break;

                case "resize":
                {

                }
                    break;

                case "exit":
                {
                    Environment.Exit(0);
                }
                    break;

                case "search":
                {

                }
                    break;

                    default:
                        Console.WriteLine("Неизвестная команда, попробуйте еще раз\n");
                        break;
            }
        }

        private string ParseCommand(string command)
        {
            string result = "";
            command += " ";
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == ' ')
                {
                    _path = command.Remove(0, result.Length).Trim();
                    return result;
                }
                else
                {
                    result += command[i];
                }
            }

            throw new FormatException("Неверный формат ввода, пожалуйста, проверьте корректность ввода");
        }

        public string GetCurrentPath()
        {
            return PathWork.GetCurrentPath();
        }

    }
}
