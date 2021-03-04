using System;

namespace Task_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Результат не округляю. Для округления поменять тип данных sum и average на int.

            float sum = 0;
            float average = 0;
            Console.WriteLine("Введите предложение: " + Environment.NewLine);
            string s = Console.ReadLine();
            string[] str = s.Split(new[] { ' ', ':', ',', '!', '?', '.', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string k in str)
            {
                sum+=k.Length;
                average = sum / str.Length;
            }

            Console.WriteLine("Средняя длина слова в данной строке: {0} букв ", average);
            Console.ReadKey();

        }
    }
}
