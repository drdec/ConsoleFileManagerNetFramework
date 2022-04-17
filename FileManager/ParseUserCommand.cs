using System;
using System.IO;

namespace FileManager
{
    internal class ParseUserCommand
    {
        private string _path;
        private readonly PathWork _pathWork;
        private readonly Directories _directories;
        private readonly FileWork _fileWork;

        public ParseUserCommand()
        {
            _pathWork = new PathWork();
            _directories = new Directories();
            _fileWork = new FileWork();
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
                    _fileWork.DeleteFile(_path);
                }
                    break;

                case "info":
                {
                    _directories.PrintDirectoriesAndFiles();
                }
                    break;

                case "move":
                {
                    _directories.MoveCatalog();
                }
                    break;

                case "copy":
                {
                    Console.WriteLine("Данная команда пока в разработе");
                }
                    break;

                case "create":
                {
                    _directories.CreateCatalog();
                }
                    break;

                case "rename":
                {
                    _directories.Rename();
                }
                    break;

                case "open":
                {
                    _fileWork.StartApplication();
                }
                    break;

                case "resize":
                {
                    Console.WriteLine("Введите название файла, если хотите узнать размер файла\n" +
                                      "В противном случае нажмите Enter");

                    string userInput = Console.ReadLine();

                    if (string.IsNullOrEmpty(userInput))
                    {
                        _directories.ResizeCatalog();
                    }
                    else
                    {
                        _fileWork.ResizeFile(userInput);
                    }
                }
                    break;

                case "exit":
                {
                    Environment.Exit(0);
                }
                    break;

                case "search":
                {
                    _directories.SearchFileAndCatalog(_path);
                }
                    break;

                default:
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неизвестная команда, попробуйте еще раз\n");
                    Console.ResetColor();
                }
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
