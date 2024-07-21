using allCommands;
using visual;

using dataRequests;//удалить

namespace _consoleWeb
{
    internal class program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            customWrite.write("/help для подсказки" +
                "\nadmin data:\n"); //admin data удалить
            string userAdmin = readInfo.readUsers(1, "1101"); //1
            customWrite.writeLine(userAdmin); //2
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
