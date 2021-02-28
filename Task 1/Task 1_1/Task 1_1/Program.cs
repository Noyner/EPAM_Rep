using System;
using System.Collections.Generic;

namespace Task_1_1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Rectangle();                         // 1.1.1
            //Triangle();                          // 1.1.2
            //AnotherTriangle();                   // 1.1.3
            //XmasTree();                          // 1.1.4
            //SumOfNumbers();                      // 1.1.5
            //FontAdj();                           // 1.1.6
            ArrayProcessing();                   // 1.1.7
            NoPositive();                        // 1.1.8
            //NonNegativeSum();                    // 1.1.9
                                                                      // 1.1.10

        }

        static void Rectangle()
        {
            Console.Write("Вычислим площадь прямоугольника\n\n");
            Console.Write("Введите значение a: ");
            int a = Int32.Parse(Console.ReadLine());
            Console.Write("Введите значение b: ");
            int b = Int32.Parse(Console.ReadLine());
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
            int height = Int32.Parse(Console.ReadLine());

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
            Console.Write("Введите высоту ёлки: ");
            int height = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < height; i++)
            {
                for (int space = 0; space < height - i - 1; space++)
                {
                    Console.Write(" ");
                }

                for (int tree = 0; tree < i * 2 + 1; tree++)
                {
                    Console.Write("*");

                }
                Console.WriteLine();


            }
            Console.ReadKey();
        }

        static void XmasTree()
        {
            Console.Write("Введите высоту многоярусной ёлки: ");
            int height = Int32.Parse(Console.ReadLine());
            for (int i=0; i<=height;i++)
            {
                for (int j=0; j<i; j++)
                {
                    string str = new String('*', j);
                    Console.WriteLine(str.PadLeft(height+3)+ "*" + str);

                }
            }

        }

        static void SumOfNumbers()
        {
            int sum = 0;
            for (int i = 0; i<1000; i++)
            {
 
                if (i%3==0 | i%5==0)
                {
                    Console.WriteLine(sum=sum+i);
                }
            }
            Console.ReadLine();
        }

        static void FontAdj()
        {
            bool flag = true;
            List < string > fonts = new List<string>();
            fonts.Add("None");
            Console.WriteLine("Параметры надписи: " + string.Join(", ", fonts));

            do
            {

                Console.WriteLine("Введите:\n 1:bold \n 2:italic \n 3:underline \n 0: exit");
                int enter = Int32.Parse(Console.ReadLine());

                switch (enter)
                {
                    case 1:
                        if (fonts.Contains("Bold")) 
                            fonts.Remove("Bold");
                        else
                        {
                            fonts.Remove("None");
                            fonts.Add("Bold");
                        }
                        Console.WriteLine("Параметры надписи: " + string.Join(", ", fonts));
                        break;
                    case 2:
                        if (fonts.Contains("Italic"))
                            fonts.Remove("Italic");

                        else
                        {
                            fonts.Remove("None");
                            fonts.Add("Italic");
                        }
                        Console.WriteLine("Параметры надписи: " + string.Join(", ", fonts));
                        break;
                    case 3:
                        if (fonts.Contains("Underline"))
                            fonts.Remove("Underline");
                        else
                        {
                            fonts.Remove("None");
                            fonts.Add("Underline");
                        }
                        Console.WriteLine("Параметры надписи: " + string.Join(", ", fonts));
                        break;
                    case 0:
                        Console.WriteLine("Конец программы");
                        flag = false;
                        break;

                }
            }
            while (flag==true);
        }
        static void ArrayProcessing()

        {
            Console.WriteLine("Что делать с массивом? \n\n 1: Сгенерировать \n 2: Вывести на экран \n 3: Max \n 4: Min \n 5: Сортировка \n");

        }
        static void NoPositive()
        {

        }
        static void NonNegativeSum()
        {   
            int[] arr = new int[10] { 1, -1, 2, -2, 3, -3, 4, -4, 5, -5 };
            int count = 0;
            Console.WriteLine("Массив целых чисел:");

            for (int i=0; i<arr.Length; i++)
            {
                if (arr[i] > 0)
                    count++;
            }

            foreach (int m in arr)
            {
                Console.WriteLine(m);
            }
            Console.WriteLine("В массиве " + count + " положительных элементов");
            Console.ReadKey();

        }
     }



            
                
}
            

            
     
        
        


