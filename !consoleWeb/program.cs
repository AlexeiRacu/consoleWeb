using allCommands;
using visual;

namespace _consoleWeb
{
    class program
    {
        public static void Main() 
        {
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
