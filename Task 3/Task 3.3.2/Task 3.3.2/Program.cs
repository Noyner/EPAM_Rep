using System;
using System.Collections.Generic;


namespace Task_3._3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку: ");
            string str = Console.ReadLine();
            str.DefineLanguage();
        }
    }

    public static class SuperString
    {
        public static void DefineLanguage(this string str)
        {
            bool Russian = false, English = false, Numbers = false, Mixed = false;
            char[] ch = str.ToCharArray();

            List<char> englishLetters = new List<char>();
            List<char> russianLetters = new List<char>();
            List<string> someSymbols = new List<string>() { " ", ".", ",", ":", ";", "!", "?" };
            List<string> numbersList = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                englishLetters.Add(letter);
                englishLetters.Add(Char.ToLower(letter));
            }

            for (char letter = 'А'; letter <= 'Я'; letter++)
            {
                russianLetters.Add(letter);
                russianLetters.Add(Char.ToLower(letter));
            }

            foreach (char c in ch)
            {
                if (englishLetters.Contains(c) & !russianLetters.Contains(c) & !someSymbols.Contains(c.ToString()) & !numbersList.Contains(c.ToString()))
                {
                    English = true;
                }
                else if (russianLetters.Contains(c) & !englishLetters.Contains(c) & !someSymbols.Contains(c.ToString()) & !numbersList.Contains(c.ToString()))
                {
                    Russian = true;
                }
                else if (numbersList.Contains(c.ToString()) & !someSymbols.Contains(c.ToString()) & !englishLetters.Contains(c) & !russianLetters.Contains(c))
                {
                    Numbers = true;
                }
                else
                {
                    Mixed = true;
                }
            }
            if (English & !Russian & !Numbers & !Mixed) { Console.WriteLine("Этот текст написан на английском"); }
            if (Russian & !English & !Numbers & !Mixed) { Console.WriteLine("Этот текст написан на русском"); }
            if (Numbers & !English & !Mixed & !Russian) { Console.WriteLine("Этот текст состоит из цифр"); }
            if (Mixed || English & Russian || English & Numbers || Russian & Numbers) { Console.WriteLine("Это смешанный текст"); }
        }
    }
}
