using allCommands;
using System.Text;
using visual;

namespace _consoleWeb
{
    class program
    {
        private static int MainCalls = 0;
        private static int PostsPageCalls = 0;
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.White;
            if(MainCalls == 0)
            {
                customWrite.writeLine("/help для описания работы с программой");
            }
            MainCalls++;
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

        public static void PostsPage(bool whithPromt = false)
        {
            customWrite.writeLine("Вы зашли на главную страницу с постами !consoleWEB");
            if (PostsPageCalls == 0)
            {
                customWrite.writeLine("/help для описания работы с страницой, /out чтобы выйти");
            }
            PostsPageCalls++;
            while (true) 
            {
                string request = Console.ReadLine();
                if (request == "" || request[0] != '/')
                {
                    customWrite.writeLine("Используйте '/' для оринтирования в программе!");
                }
                else
                {
                    postsPageCommands.identifyCommand(request);
                }
            }
        }
    }
}
