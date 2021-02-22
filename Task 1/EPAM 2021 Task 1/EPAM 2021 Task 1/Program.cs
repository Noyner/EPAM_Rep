using System;
namespace EPAM_2021_Task_1

{
    class Program
    {
        static void Main(string[] args)
        {

            Rectangle();              // 1.1.1
            Triangle();               // 1.1.2
            AnotherTriangle();          // 1.1.3
                                        // 1.1.4
                                        // 1.1.5
                                        // 1.1.6
                                        // 1.1.7
                                        // 1.1.8
                                        // 1.1.9
                                        // 1.1.10

        }

        static void Rectangle()
        {
            Console.Write("Вычислим площадь прямоугольника\n\n");
            Console.Write("Введите значение a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите значение b: ");
            int b = Convert.ToInt32(Console.ReadLine());
            int c = a * b;
            if (a <= 0 || b <= 0)
            {
                Console.Write("Стороны прямоугольника должны быть больше нуля!\n");
            }
            else
            {
                Console.Write("Площадь прямоугольника = " + c);
                Console.ReadKey();
            }

        }

        static void Triangle()
        {
            Console.Write("Введите высоту труегольника: ");
            int height = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();

            }
            Console.ReadKey();
        }

        static void AnotherTriangle()
        {

        }

    }
}

