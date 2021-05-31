using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_3._3._3
{

    class Pizzeria
    {
        public static int OrderId { get; set; }

        static Queue<int> orders = new Queue<int>();

        public void AddOrder(Client client)
        {
            OrderId += 1;
            orders.Enqueue(OrderId);
            Console.WriteLine("{0}, номер вашего заказа - {1}. Пожалуйста, ожидайте", client.Name, OrderId);
            CreatePizza();
        }

        public static void DeleteOrder()
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

        public static async void CreatePizza()
        {
            var task = new Task(() => { Console.WriteLine(Environment.NewLine + "Заказ под номером {0} готов. Заберите заказ", orders.Last()); });
            task.Wait(TimeSpan.FromSeconds(5));
            task.Start();
            await task;
        }

        public void GivePizza()
        {
            Console.WriteLine("Клиент забрал заказ под номером {0}", orders.First());
            DeleteOrder();
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
}
