using System;

namespace Task_3._3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Desktop desktop = new Desktop();
            desktop.Menu();
        }
    }

    class CheesePizza : Pizza
    {
        public CheesePizza() : base("Сырная пицца") { }
        public override int GetCost()
        {
            Console.WriteLine("Стоимость сырной пиццы - 100 пенни");
            return 100;
        }
    }

    class SicilianPizza : Pizza
    {
        public SicilianPizza() : base("Сицилийская пицца") { }
        public override int GetCost()
        {
            Console.WriteLine("Стоимость Сицилийской пиццы - 150 пенни");
            return 150;
        }
    }
    class Margarita : Pizza
    {
        public Margarita() : base("Маргарита") { }
        public override int GetCost()
        {
            Console.WriteLine("Стоимость Маргариты - 70 пенни");
            return 70;
        }
    }
}


