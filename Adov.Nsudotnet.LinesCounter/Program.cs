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
            foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory(), args[0], SearchOption.AllDirectories))
            {
                Console.WriteLine(file);
                int line = File.ReadLines(file).Count(metod);
                    
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }
        static bool metod(string line)
        {
            if (line.Trim().StartsWith("//"))
            {
                return false;
            }
            return true;
        }
    }
}