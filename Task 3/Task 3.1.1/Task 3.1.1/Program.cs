using System;
using System.Collections.Generic;

namespace Task_3._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество участников: ");
            int N = Int32.Parse(Console.ReadLine());

            List<int> peoples = new List<int>(N) { };

            for (int i = 1; i < N+1; i++)
            {
                peoples.Add(i);
            }

            //foreach (int k in peoples)
            //{
            //    Console.WriteLine(k);
            //}

            for (int i = 1; i <= peoples.Count; i++)
            {
                peoples.Remove(peoples[1]);
                Console.WriteLine("Удалён {0}", peoples[1]);
                Console.ReadKey();
                foreach(int k in peoples)
                {
                    Console.WriteLine(k);
                    Console.ReadKey();
                }
            }



        }
    }
}
