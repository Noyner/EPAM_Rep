using System;
using System.Text;

namespace Task_2

{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет! Введи первую строку: " + Environment.NewLine);
            NewStr s1 = new NewStr { str = Console.ReadLine() };
            Console.WriteLine("А теперь введи вторую строку: " + Environment.NewLine);
            NewStr s2 = new NewStr { str = Console.ReadLine() };



            //bool result = s1 > s2;
            //Console.WriteLine(result);

            //bool result2 = s1 == s2;
            //Console.WriteLine(result2);


            //Console.WriteLine(s1.str + s2.str);                      \

            //Console.WriteLine();
            //s1.SearchIndex();                                         // Поиск символа в строке

            //s1.SearchStr();                                           // Поиск подстроки в строке

            
            //NewStr ind = new NewStr();
            //ind[0] = new NewStr { str = "Test String" };
            //ind[1] = new NewStr { str = "One More Test String" };      // Вызов индексатора 

            //NewStr TestInd = ind[0];
            //Console.WriteLine(TestInd.str);


            Console.ReadKey();

        }
    }
    class NewStr
    {
        
        internal string str { get; set; }

        public void ToCharArr()
        {
            str.ToCharArray();
            Console.WriteLine(str);
            foreach (char k in str)
            {
                Console.WriteLine(k);
            }
        }

        public void ToStr()
        {
            str.ToString();
            Console.WriteLine("Массив символов успешно проеобразован в строку! " + Environment.NewLine + str);
        }

        public void SearchIndex()
        {
            Console.WriteLine("Какой символ в строке хочешь найти: ");
            int IndexOfChar = str.IndexOf(Console.ReadLine());
            Console.WriteLine("Позиция символа в строке: " + IndexOfChar);
            Console.ReadKey();
        }

        public void SearchStr()
        {
            Console.WriteLine("Какую подстроку ты хочешь найти в строке: ");
            string s = Console.ReadLine();
            bool ContStr = str.Contains(s);
            Console.WriteLine(Environment.NewLine + ContStr);
            Console.ReadKey();
        }

        // Переопределяем операторы 

        public static NewStr operator +(NewStr s1, NewStr s2)
        {
            return new NewStr { str = s1.str + s2.str };
        }

        public static bool operator <(NewStr s1, NewStr s2)
        {
            return s1.str.Length < s2.str.Length;
        }

        public static bool operator >(NewStr s1, NewStr s2)
        {
            return s1.str.Length > s2.str.Length;
        }

        public static bool operator ==(NewStr s1, NewStr s2)
        {
            return object.Equals(s1.str, s2.str);
        }

        public static bool operator !=(NewStr s1, NewStr s2)
        {
            return !object.Equals(s1.str, s2.str);
        }

        //public override bool Equals(object str)
        //{
        //    return CompareTo(str as NewStr) == 0;

        //}

        // Индексатор 
        public NewStr()
        {
            data = new NewStr[5];
        }

        NewStr[] data;

        public NewStr this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }

        }

        

    }
}
