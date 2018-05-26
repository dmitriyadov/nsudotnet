using System;
using System.IO;

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
            char[] buffer = new char[1024];
            foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory(), args[0], SearchOption.AllDirectories))
            {
                using (StreamReader sr = File.OpenText(file))
                {
                    while (!sr.EndOfStream)
                    {
                        int read = sr.Read(buffer, 0, buffer.Length);
                        count += Netod(buffer, read);
                    }
                }
                Console.WriteLine(count + " - " + file);
            }
            Console.WriteLine("Количество осмысленных строк равно: " + count);
            Console.ReadLine();
        }
        static bool newString = true;
        static int Netod(char[] arr, int length)
        {     
            int count = 0;
            int i = 0;
            while (i < length)
            {
                if (newString == true)
                {
                    if (char.IsWhiteSpace(arr[i]))
                    {
                        i++;
                        continue;
                    }

                    if ((arr[i] == '/') && (arr[i+1] == '/'))
                    {
                        i+=2;
                        while (i < length)
                        {
                            if (arr[i] == '\n')
                            {
                                i++;
                                break;
                            }
                            i++;
                        }
                    }
                    if ((arr[i] == '/') && (arr[i + 1] == '*'))
                    {
                        i += 3;
                        while (i < length)
                        {
                            if (arr[i - 1] == '*' && arr[i] == '/')
                            {
                                i++;
                                break;
                            }
                            i++;
                        }
                        continue;
                    }
                    newString = false;
                    continue;
                }
                if (newString == false)
                {
                    if (arr[i] == '\n')
                    {
                        count++;
                        newString = true;
                    }
                    i++;
                }
            }
            return count;
        }
    }
}