using System;
using System.Collections.Generic;

namespace Task_3._3._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N участников: ");
            int N = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Сгенерирован круг людей. Начинаем вычёркивать каждого второго");

            int[] myArray = new int[N];

            for (int i = 0; i < N; i++)
            {
                myArray[i] = 1 + i;
            }

            LinkedList<int> circle = new LinkedList<int>(myArray);
            var current = circle.First;

            while (circle.Count != 0)
            {
                foreach (int k in circle)
                {
                    Console.WriteLine(k);
                }

                Console.WriteLine(Environment.NewLine + "Осталось {0} человек", circle.Count);
                Console.WriteLine();
                circle.Remove(current.Next ?? circle.First);
                current = current.Next ?? circle.First;
            }
        }
    }
}
