using allCommands;
using System.Text;
using visual;

namespace _consoleWeb
{
    class program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                string request = Console.ReadLine();
                if (request == "" || request[0] != '/')
                {
                    customWrite.writeLine("Используйте '/' для оринтирования в программе!");
                }
                else
                {
                    mainCommands.identifyCommand(request);
                }
            }
        }
    }
}
