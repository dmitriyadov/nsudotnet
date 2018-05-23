using System;

namespace Adov.Nsudotnet.NumberGuesser
{
    class Program
    {
        private static Random Random = new Random();

        static void Main(string[] args)
        {
            string[] SwearWords =
            {
            "Распаять мои контакты! {0}, я vpn быстрее поднял. ",
            "{0}, а ты попробуй 47. Не зря же маман лишней наградила.",
            "Ебен-бобен, {0}, какой же ты тупой...",
            "{0}, Есть два стула...",
            "{0}, cиний кит — самое большое современное животное, а также, вероятно, " +
            "крупнейшее из всех животных, когда-либо существовавших на Земле. Его длина достигает 33 метров, а ты петух.",
            "{0}, еще скажи, что ты аниме смотришь...",
            };
            Console.WriteLine("Псс, парень, имя введи");
            var name = Console.ReadLine();
            int randomNamber = Random.Next(100);
            var history = new Tuple<int, bool>[1000];
            Console.WriteLine("А теперь угадай число от 0 до 100, пес");
            DateTime startTime = DateTime.Now;
            int namberTry = 0;
            while (true)
            {
                namberTry++;
                string input = Console.ReadLine();
                if (input == "q")
                {
                    Console.WriteLine("Дружище, извини, я перегнул");
                    Console.ReadLine();
                    return;
                }

                if (!int.TryParse(input, out int inputNamber))
                {
                    namberTry--;
                    Console.WriteLine("Ты чего мычишь, нужно число");
                    continue;
                }

                if (randomNamber ==  inputNamber)
                {
                    var time = DateTime.Now.Subtract(startTime).TotalMinutes;
                    Console.WriteLine($"\nТысяча поздравлений! \nКоличество попыток: {namberTry}\nКоличество затраченных минут: {time} \n\nВот твоя история:");
                    for (int i = 0; i < namberTry - 1; i++)
                    {    
                            string answerStat = history[i].Item2 ? "Много" : "Мало";
                            Console.WriteLine(history[i].Item1 + "\t" + answerStat);     
                    }
                    Console.WriteLine(inputNamber + "\tСамое то");
                    break;
                }

                bool res = inputNamber > randomNamber;
                history[namberTry - 1] = new Tuple<int, bool>(inputNamber, res);
                Console.WriteLine("Попробуй ввести число " + (res ? "меньше" : "больше"));
                if (namberTry % 4 == 0)
                {           
                    string insult = SwearWords[Random.Next(SwearWords.Length)];
                    Console.WriteLine(string.Format(insult, name) + "\n");
                    string.Format(insult, name);
                }
            }
            Console.ReadLine();
        }
    }
}