using System;
using System.IO;
using System.Linq;

namespace Adov.Nsudotnet.LinesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Write("Дядя, программа принимает параметром командной строки тип учитываемых файлов (например, *.cs)");
                Console.Read();
                return;
            }
            int count = 0;
            foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory(), args[0], SearchOption.AllDirectories))
            {
                int line = File.ReadLines(file).Count(Netod);
                if (nowWeInCom == false)
                {
                    count += line;
                }
               // Console.WriteLine(line + " - " + file);
            }
            Console.WriteLine("Количество осмысленных строк равно: " + count);
            Console.ReadLine();
        }

        static bool nowWeInCom = false;

        static bool Netod(string line)
        {
            if (((line.Trim().StartsWith("//")) && (nowWeInCom == false)) || (string.IsNullOrWhiteSpace(line)))
            {
                return false;
            }
            

            int i = 0;
            while(i < line.Length-1)
            {
                if ((line[i] == '/') && (line[i + 1] == '*'))
                {
                    Console.WriteLine(line[i]);
                    nowWeInCom = true;
                }
                if ((line[i] == '*') && (line[i + 1] == '/'))
                {
                    nowWeInCom = false;
                }


                
                i++;
            }
            Console.WriteLine(nowWeInCom);



            return true;
        }
    }
}