using System;
using System.Globalization;
using System.Linq;

namespace Adov.Nsudotnet.Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите дату");
            var input = Console.ReadLine();
            if (!DateTime.TryParse(input, out var inputDate))
            {
                Console.WriteLine("Попробуйте в следующий раз ввести дату в другом формате, например, чч.мм.гггг");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("\n" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(inputDate.Month) + " " + inputDate.Year);
            var daysOfWeek = Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().OrderBy(day => day < CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

            foreach (var day in daysOfWeek)
            {
                Console.Write(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedDayName(day) + "\t");
            }

            Console.WriteLine();
            var daysInMonth = DateTime.DaysInMonth(inputDate.Year, inputDate.Month);
            var dayOfMonth = new DateTime(inputDate.Year, inputDate.Month, 1);
            int daysFromLastMonth = (dayOfMonth.DayOfWeek - daysOfWeek.First() + 7) % 7;
            int daysFromNextMonth = 7 - ((daysInMonth + daysFromLastMonth) % 7);
            dayOfMonth = dayOfMonth.AddDays(-1 * daysFromLastMonth);
            var workingDays = daysInMonth;

            for (int i = 0; i < daysInMonth + daysFromLastMonth + daysFromNextMonth;)
            {
                if ((dayOfMonth.DayOfWeek == DayOfWeek.Saturday) || (dayOfMonth.DayOfWeek == DayOfWeek.Sunday))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (dayOfMonth.Month == inputDate.Month)
                    {
                        workingDays--;
                    }
                }    
                if (dayOfMonth.Date == DateTime.Now.Date)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else if (dayOfMonth == inputDate)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                if (dayOfMonth.Day / 10 == 0)
                {
                    Console.Write(" " + dayOfMonth.Day + "\t");
                }
                else
                {
                    Console.Write(dayOfMonth.Day + "\t");
                }
            
                if (dayOfMonth.DayOfWeek == daysOfWeek.Last())
                {
                    Console.WriteLine();
                }
                Console.ResetColor();
                dayOfMonth = dayOfMonth.AddDays(1);
                i++;
            }

            Console.WriteLine("\nЧисло рабочих дней, без учета праздников: " + workingDays);
            Console.ReadLine();
        }
    }
}