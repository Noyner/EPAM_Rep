using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task_3._2
{
    class DynamicArray<T> : IEnumerable<T>, IEnumerable, ICloneable
    {
        private T[] array;
        private static int ArrayCapacity;
        private int count = 0;

        public DynamicArray()
        {
            ArrayCapacity = 8;
            array = new T[count];
        }

        public DynamicArray(int ArrayCapacity)
        {
            Console.WriteLine("Введите ёмкость массива: ");
            ArrayCapacity = Int32.Parse(Console.ReadLine());
            array = new T[ArrayCapacity];
        }

        public DynamicArray(IEnumerable<T> SomeCollecton)
        {
            array = SomeCollecton.ToArray();
        }

        public void Add(T element)
        {
            ExpansionArray();
            array[count++] = element;
        }

        public void AddRange(IEnumerable<T> SomeCollection)
        {
            ExpansionArray();
            var result = SomeCollection.Union(array);
            foreach (T i in SomeCollection)
            {
                Add(i);
            }
        }
        public void RemoveAt(int indexOfElement)
        {
            int translation = indexOfElement + 1;
            if (translation < count)
            {
                Array.Copy(array, translation, array, indexOfElement, count - translation);
            }
            count--;
        }

        public bool Remove(T element)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i].Equals(element))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        private void ExpansionArray()
        {
            int newCapacity = Capacity == 0 ? 4 : Capacity * 2;
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < array.Length; i++)
                newArray[i] = array[i];

            array = newArray;
        }
        public void Insert(int indexOfElement, T element)
        {
            if (array.Length == count)
            {
                ExpansionArray();
            }

            for (var i = count - 1; i > indexOfElement; i--)
            {
                array[i] = array[i - 1];
            }
            array[indexOfElement] = element;
        }

        public void GetLenght()
        {
            Console.WriteLine("Длина массива: " + array.Length + Environment.NewLine);
        }

        public T this[int index]
        {
            get
            {
                return array[index];
            }

            set
            {
                array[index] = value;
            }
        }
        public int Length => array.Count();

        private int Capacity => ArrayCapacity;

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
        }

        public object Clone()
        {
            return array.Clone();
        }
    }
}
