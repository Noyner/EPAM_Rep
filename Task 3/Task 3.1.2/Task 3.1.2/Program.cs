using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_3._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new TextAnalysis();
            text.GetInfo();
        }
    }
    class TextAnalysis
    {
        string Text;
        string[] Words;
        Dictionary<string, int> WordsDict;
        string[] spliters = new string[] { " ", ":", ",", "!", "?", ".", ";", "(", ")", "<",">"};

        public TextAnalysis()
        {
            Console.WriteLine("Введите текст: " + Environment.NewLine);
            Text = Console.ReadLine();
            Calculation();
        }
        public void Calculation()
        {
            WordsDict = new Dictionary<string, int>();
            Words = Text.ToLower().Split(spliters, StringSplitOptions.RemoveEmptyEntries);
            foreach(var word in Words)
            {
                if (WordsDict.ContainsKey(word))
                {
                    WordsDict[word]++;
                }
                else
                {
                    WordsDict[word] = 1;
                }
            }
        }
        public void GetInfo()
        {
            var sortedDict = from entry in WordsDict orderby entry.Value descending select entry;
            Console.WriteLine(Environment.NewLine + "Информация о тексте" + Environment.NewLine);
            Console.WriteLine("Текст: {0}", Text);
            Console.WriteLine("Количество слов в тексте: {0}", Words.Length);
            Console.WriteLine("Уникальных слов: {0}", WordsDict.Keys.Count);

            foreach(var word in sortedDict)
            {
                Console.WriteLine(word);
            }
        }
    }
}
