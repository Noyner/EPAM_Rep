using System;
using System.Text;
using MyLib;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            manager.Menu();

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
        public override bool Equals(object obj)
        {
            NewStr myStr = obj as NewStr;

            if (myStr == null)
            {
                return false;
            }
            return myStr.str == this.str;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        // Индексатор 
        public NewStr()
        {
            data = new NewStr[5];
        }
        readonly NewStr[] data;
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
        public void GetIndexator()
        {
            NewStr ind = new NewStr();
            Console.WriteLine("Вызываю индексатор и добавляю в него две строки");
            ind[0] = new NewStr { str = "Test String" };
            ind[1] = new NewStr { str = "One More Test String" };      // Вызов индексатора 

            NewStr TestInd1 = ind[0];
            NewStr TestInd2 = ind[1];
            Console.WriteLine("Первая строка: " + TestInd1.str);
            Console.WriteLine("Вторая строка: " + TestInd2.str);
        }
    }
    class Manager : NewStr
    {
        public void Menu()
        {
            Console.WriteLine("Привет! Введите строку: " + Environment.NewLine);
            NewStr s1 = new NewStr { str = Console.ReadLine() };
            bool swBool = true;
            do
            {
                Console.WriteLine(Environment.NewLine + "Выберите действие:\n \n1. Конвертировать в массив символов \n2. Найти символ в строке \n3. Найти подстроку в строке \n4. Конвертировать в строку \n5. Индексатор \n6.Вызов DLL**  \n0. Выход ");
                string enter = Console.ReadLine();
                switch (enter)
                {
                    case "1":
                        s1.ToCharArr();
                        break;
                    case "2":
                        s1.SearchIndex();
                        break;
                    case "3":
                        s1.SearchIndex();
                        break;
                    case "4":
                        s1.ToStr();
                        break;
                    case "5":
                        s1.GetIndexator();
                        break;
                    case "6":
                        Helper.Hello();
                        break;
                    case "0":
                        Console.WriteLine("Конец программы");
                        swBool = false;
                        break;
                    default:
                        Console.WriteLine("Вы ввели неверное значение");
                        break;
                }
            }
            while (swBool);
        }
    }
}
