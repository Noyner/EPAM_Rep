using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> newD = new DynamicArray<int>();
            newD.Add(5);
            newD.Add(10);
            newD.GetLenght();
            //List<int> numbers = new List<int>() { 1, 2, 3, 45 };
            //newD.AddRange(numbers);

            foreach (var i in newD)
            {
                Console.WriteLine(i);
            }
        }
    }
}
