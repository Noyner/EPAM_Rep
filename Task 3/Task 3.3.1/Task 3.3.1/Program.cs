using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3._3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new[] { 1, 2, 3, 4, 5, 5, 5 };

            array.SumOfElements();
            array.AverageValue();
            array.Repeated();
        }
    }

    public static class IntArrayExtensions
    {

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
            {
                action(element);
            }
        }
        public static int SumOfElements(this IEnumerable<int> collection)
        {
            int sum = collection.Sum();
            Console.WriteLine(Environment.NewLine + "Сумма элементов массива: {0}", sum);
            return sum;
        }

        public static int AverageValue(this IEnumerable<int> collection)
        {
            double average = collection.Average();
            Console.WriteLine(Environment.NewLine + "Среднее арифметическое в массиве: {0}", (int)average + Environment.NewLine);
            return (int)average;
        }

        public static int Repeated(this IEnumerable<int> collection)
        {
            var repeated = collection.GroupBy(x => x).OrderByDescending(x => x.Count()).First();
            Console.WriteLine("Наиболее часто встречается цифра {0} в количестве {1} раз", repeated.Key, repeated.Count());
            return 1;
        }
    }
}
