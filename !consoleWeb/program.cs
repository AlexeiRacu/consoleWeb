using allCommands;
using visual;

namespace _consoleWeb
{
    internal class program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            customWrite.writeLine("/help для подсказки");
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
