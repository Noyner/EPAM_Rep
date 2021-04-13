using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
            OrderId += 1;
            orders.Enqueue(OrderId);
            Console.WriteLine("{0}, номер вашего заказа - {1}. Пожалуйста, ожидайте", client.Name, OrderId);

            //if (orders != null)
            //{
            //    ThreadStart ts = new ThreadStart();
            //    ts.GoThread();
            //}
        }

        public void DeleteOrder()
        {
            orders.Dequeue();
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

        public void GivePizza()
        {
            if (orders == null)
            {
                Console.WriteLine("Нет активных заказов");
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "Заказ под номером {0} готов. Заберите заказ", orders.First());
                DeleteOrder();
            }
        }

        public void ShowOrders()
        {
            Console.WriteLine("Заказов в работе: {0}" + Environment.NewLine, orders.Count);

            foreach (int i in orders)
            {
                Console.WriteLine("Заказ под номером {0}", i);
            }
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

    class Desktop
    {
        Pizzeria pizzeria = new Pizzeria();
        public void Menu()
        {
            bool swBool = true;
            do
            {
                Console.WriteLine("Пиццерия Pizza-Super-Puper приветствует вас!" + Environment.NewLine + Environment.NewLine + "Выберите действие: \n1. Сделать заказ \n2. Заказы в работе \n3. Забрать заказ \n0. Выход ");
                string enter = Console.ReadLine();
                switch (enter)
                {
                    case "1":
                        Console.WriteLine(Environment.NewLine + "Как к вам обращаться?");
                        Client client = new Client(Console.ReadLine());
                        pizzeria.ChoosePizza();
                        pizzeria.AddOrder(client);
                        break;
                    case "2":
                        pizzeria.ShowOrders();
                        break;
                    case "3":
                        pizzeria.GivePizza();
                        break;
                    case "0":
                        Console.WriteLine("Спасибо, что пришли!");
                        swBool = false;
                        break;
                }

            }
            while (swBool);

        }
    }

    class ThreadStart
    {
        public void GoThread()
        {
            Thread thread = new Thread(Metod);
            thread.Start(1500);
            thread.Join();
        }

    static void Metod(object timeout)
        {
            Thread.Sleep((int)timeout);
            Pizzeria pizzeria = new Pizzeria();
            pizzeria.GivePizza();
        }
    }
}


