using System;
using System.Collections.Generic;

namespace Task_1_1
{
    class Program
    {
        static void Main(string[] args)
        {

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
                for (int i = 0; i <= height; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        string str = new String('*', j);
                        Console.WriteLine(str.PadLeft(height + 3) + "*" + str);

                    }
                }

            }

            static void SumOfNumbers()
            {
                int sum = 0;
                for (int i = 0; i < 1000; i++)
                {

                    if (i % 3 == 0 | i % 5 == 0)
                    {
                        Console.WriteLine(sum = sum + i);
                    }
                }
                Console.ReadLine();
            }

            static void FontAdj()
            {
                bool flag = true;
                List<string> fonts = new List<string>();
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
                while (flag == true);
            }

            static void ArrayProcessing()

            {

                int n;

                Console.WriteLine("Введите число элементов массива: ");
                n = int.Parse(Console.ReadLine());
                int[] array = new int[n];
                int min = 101;
                int max = -1;
                int c;

                Random rand = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rand.Next(100);
                    if (min > array[i])
                        min = array[i];
                    if (max < array[i])
                        max = array[i];
                }

                Console.WriteLine(Environment.NewLine + "Массив: " + Environment.NewLine);
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (array[i] > array[j])
                        {
                            c = array[i];
                            array[i] = array[j];
                            array[j] = c;
                        }

                    }

                }
                foreach (int m in array)
                {
                    Console.WriteLine(m);
                }
                Console.WriteLine(Environment.NewLine + "Минимальный элемент массива: " + min);
                Console.WriteLine("Максимальный элемент массива: " + max);
            }

            static void NoPositive()
            {

                int[,,] array = new int[3, 3, 3];

                Random rand = new Random();
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        for (int k = 0; k < array.GetLength(2); k++)
                        {
                            array[i, j, k] = rand.Next(-150, 150);
                            if (array[i, j, k] > 0)
                            {
                                array[i, j, k] = 0;
                            }

                        }

                    }
                }

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        for (int k = 0; k < array.GetLength(2); k++)
                        {
                            Console.WriteLine(array[i, j, k] + " ");

                        }
                        Console.WriteLine(" ");
                    }
                    Console.WriteLine("------");
                }
            }

            static void NonNegativeSum()
            {
                int[] arr = new int[10] { 1, -1, 2, -2, 3, -3, 4, -4, 5, -5 };
                int count = 0;
                Console.WriteLine("Массив целых чисел:");

                for (int i = 0; i < arr.Length; i++)
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

            static void TwoDArr()
            {
                int[,] arr = new int[3, 3]
                {
                {1,2,3 },
                {4,5,6 },
                {7,8,9 }

                };
                int height = arr.GetLength(0);
                int width = arr.GetLength(1);
                int sum = 0;
                for (int i = 0; i < height; i++)
                {
                    for (int k = 0; k < width; k++)
                    {
                        if ((i + k) % 2 == 0)
                        {
                            sum += arr[i, k];
                        }
                    }

                }
                Console.WriteLine(sum);
            }


            bool flag1 = true;
            do
            {

                Console.WriteLine(Environment.NewLine + "Выберите задание:\n 1: Rectangle \n 2: Triangle \n 3: Another Triangle \n 4: X-mas tree \n 5: Sum of numbers" +
                    "\n 6: Font adjusment \n 7: Array processing \n 8: No positive \n 9: Non-negative \n 10: 2D Array \n 0: Выход");

                int ent = Int32.Parse(Console.ReadLine());

                switch (ent)
                {
                    case 1:
                        Rectangle();
                        break;

                    case 2:
                        Triangle();
                        break;
                    case 3:
                        AnotherTriangle();
                        break;
                    case 4:
                        XmasTree();
                        break;
                    case 5:
                        SumOfNumbers();
                        break;
                    case 6:
                        FontAdj();
                        break;
                    case 7:
                        ArrayProcessing();
                        break;
                    case 8:
                        NoPositive();
                        break;
                    case 9:
                        NonNegativeSum();
                        break;
                    case 10:
                        TwoDArr();
                        break;
                        

                    case 0:
                        Console.WriteLine("Конец программы");
                        flag1 = false;
                        break;

                }
            }
            while (flag1 == true);



        }


    
        

       
        
        
            

           
        
    }

}

