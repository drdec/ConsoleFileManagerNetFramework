using System;

namespace FileManager
{
    public class ConsoleUserInput
    {
        public void UserInput()
        {
            ParseUserCommand input = new ParseUserCommand();

            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Текущее нахождение : ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(input.GetCurrentPath());
                    Console.ResetColor();

                    Console.WriteLine();

                    Console.WriteLine("Список команд :\n" +
                                      "cd - перейти в папку\n" +
                                      "path - перейти по конкретному пути\n" +
                                      "info - выводит инормацию о лежащих внутри файлах и каталогах\n" +
                                      "\\ - вернуться на папку выше\n" +
                                      "create - создать каталог\n" +
                                      "deldir - удалить папку\n" +
                                      "delfile - удалить файл\n" +
                                      "move - пермещает данный каталог\n" +
                                      "open - открыть файл\n" +
                                      "rename - переименовать файл\\папку\n" +
                                      "resize - вернуть длину файла\\папки\n" +
                                      "search - поиск папке файла\\папки\n" +
                                      "exit - выход из программы\n");

                    string str = Console.ReadLine();
                    Console.WriteLine();
                    input.Input(str);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
            }
        }
    }
}
