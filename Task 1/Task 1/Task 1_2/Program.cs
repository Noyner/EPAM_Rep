using System;
using System.Text;

namespace Task_1_2
{
    class Program
    {
        static void Main(string[] args)
        {

            static void Averages()
            {
                // Результат не округляю. Для округления поменять тип данных sum и average на int.

                int sum = 0;
                float average = 0;
                Console.WriteLine("Введите предложение: " + Environment.NewLine);
                string s = Console.ReadLine();
                string[] str = s.Split(new[] { ' ', ':', ',', '!', '?', '.', ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string k in str)
                {
                    sum += k.Length;
                    average = sum / str.Length;
                }

                Console.WriteLine("Средняя длина слова в данной строке: {0} букв ", average);
                Console.ReadKey();
            }

            static void Doubler()
            {

                Console.WriteLine("Введите первую строку: " + Environment.NewLine);
                StringBuilder one = new StringBuilder(Console.ReadLine());
                Console.WriteLine(Environment.NewLine + "Введите вторую строку: " + Environment.NewLine);
                StringBuilder two = new StringBuilder(Console.ReadLine());
                string result = "";

                foreach (char check in one.ToString())
                {
                    if (two.ToString().Contains(check))

                    {
                        result += check;
                    }

                    result += check;
                }

                Console.WriteLine(result);
                Console.ReadKey();
            }

            static void Lowercase()

            {
                Console.WriteLine("Введите строку: " + Environment.NewLine);
                string str = Console.ReadLine();
                string[] words = str.Split(new char[] { ' ', ':', ',', '!', '?', '.', ';' }, StringSplitOptions.RemoveEmptyEntries); ;
                int lower = 0;
                foreach (string s in words)
                {
                    if (char.IsLower(s[0]))
                    {
                        lower++;
                    }
                }
                Console.WriteLine(Environment.NewLine + "В строке {0} слов начинаются с маленькой буквы", lower);
                Console.ReadKey();
            }

            bool swBool = true;
            do
            {
                Console.WriteLine(Environment.NewLine + "Выберите задание:\n 1: Averages \n 2: Doubler \n 3: Lowercase \n 0: Выход");

                int ent = Int32.Parse(Console.ReadLine());

                switch (ent)
                {
                    case 1:
                        Averages();
                        break;

                    case 2:
                        Doubler();
                        break;
                    case 3:
                        Lowercase();
                        break;
                    case 0:
                        Console.WriteLine("Конец программы");
                        swBool = false;
                        break;
                }
            }
            while (swBool);
        }
    }
}
