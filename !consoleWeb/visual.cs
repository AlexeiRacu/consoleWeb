using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using _consoleWeb;

namespace visual
{
    class customWrite
    {
        static private byte timeSleep = 8;
        public static void setSpeed(string newSpeed)
        {
            newSpeed = newSpeed.ToLower();
            switch (newSpeed)
            {
                case "0":
                    timeSleep = 0;
                    customWrite.writeLine("Скорость успешно изменена!");
                    break;
                case "fast":
                    timeSleep = 2;
                    customWrite.writeLine("Скорость успешно изменена!");
                    break;
                case "normal":
                    timeSleep = 8;
                    customWrite.writeLine("Скорость успешно изменена!");
                    break;
                case "slow":
                    timeSleep = 23;
                    customWrite.writeLine("Скорость успешно изменена!");
                    break;
                default:
                    customWrite.writeLine("Несуществующий параметр!");
                    break;
            }
        }
        public static void write(string request = "")
        {
            for (int i = 0; i < request.Length; i++)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        Console.Write(request.Substring(i));
                        break;
                    }
                }
                Thread.Sleep(timeSleep);
                Console.Write(request[i]);
            }
        }
        public static void writeLine(string request = "")
        {
            for (int i = 0; i < request.Length; i++)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        Console.Write(request.Substring(i));
                        break;
                    }
                }
                Thread.Sleep(timeSleep);
                Console.Write(request[i]);
            }
            Console.WriteLine();
        }
    }
}
