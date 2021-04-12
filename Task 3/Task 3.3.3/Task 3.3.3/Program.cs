using System;
using System.Collections.Generic;

namespace Task_3._3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Клиент приходит в пиццерию");
            Pizzeria pizzeria = new Pizzeria();

            Client client = new Client("Sam");
            pizzeria.ChoosePizza();
            pizzeria.AddOrder(client);

            Client client2 = new Client("John");
            pizzeria.ChoosePizza();
            pizzeria.AddOrder(client2);

            pizzeria.GivePizza(client);
        }
    }

    class Client
    {
        public string Name { get; private set; }
        public Client(string name)
        {
            this.Name = name;
        }
    }

    class Pizzeria
    {
        public int OrderId { get; set; }

        Queue<int> orders = new Queue<int>();

        public void AddOrder(Client client)
        {
            OrderId += 1; ;
            orders.Enqueue(OrderId);
            Console.WriteLine("Здравствуйте {0}, номер вашего заказа - {1}. Пожалуйста, ожидайте", client.Name, OrderId);
        }
        public void ChoosePizza()
        {
            Console.WriteLine(Environment.NewLine + "Выберите пиццу: \n1.Сырная \n2.Сицилийская \n3.Маргарита ");
            int choice = Int32.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Pizza pizza1 = new CheesePizza();
                pizza1.GetCost();
            }
            else if (choice == 2)
            {
                Pizza pizza2 = new SicilianPizza();
                pizza2.GetCost();
            }
            else if (choice == 3)
            {
                Pizza pizza3 = new Margarita();
                pizza3.GetCost();
            }
            else
            {
                Console.WriteLine("Введено некорректное значение");
            }
        }

        public void GivePizza(Client client)
        {
            Console.WriteLine(Environment.NewLine + "{0}, ваша пицца готова. Заберите заказ", client.Name);
        }
    }

    abstract class Pizza
    {
        public string Name { get; protected set; }
        public abstract int GetCost();
        public Pizza(string n)
        {
            this.Name = n;
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
