using System;
using System.Collections.Generic;

namespace Task_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> newD = new DynamicArray<int>();
            //newD.Add(1);
        }
    }

    class DynamicArray<T>
    {
        public T[] array;
        public int ArrayCapacity;
        public int count = 1;
        public DynamicArray()
        {
            ArrayCapacity = 8;
            array = new T[8];
        }

        public DynamicArray(int ArrayCapacity)
        {
            Console.WriteLine("Введите ёмкость массива: ");
            ArrayCapacity = Int32.Parse(Console.ReadLine());
            array = new T[ArrayCapacity];
        }

        //public DynamicArray(IEnumerable<T>) ----------- 3
        //{

        //}

        public void Add (T element)
        {
            array[count] = element;
            count++;
        }

        public IEnumerable<T> AddRange()
        {
            return null;
        }

        public void Remove()
        {

        }

        public int Lenght => array.Length;
        public int Capacity
        {
            get
            {
                
                return ArrayCapacity;     
            }

            private set
            {
                Capacity = ArrayCapacity;
            }
        }
    }
}
