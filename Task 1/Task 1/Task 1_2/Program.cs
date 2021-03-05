using System;

namespace Task_1_2
{
    class Program
    {
        static void Main(string[] args)
        {

            //Averages(); // 1.2.1
            Doubler();


            static void Averages()
            {
                // Результат не округляю. Для округления поменять тип данных sum и average на int.

                float sum = 0;
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
                string one = Console.ReadLine();
                Console.WriteLine(Environment.NewLine + "Введите вторую строку: " + Environment.NewLine);
                string two = Console.ReadLine();
                string result = "";
                

               foreach(char check in one)
                {
                    if (two.Contains(check))

                    {
                        result += check;
                        result += check;
                    }

                    else

                    {
                        result += check;
                    }
                    
                }

                Console.WriteLine(result);
                Console.ReadKey();






            }



        }
    }
}
