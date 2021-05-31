using System;

namespace Task_3._3._3
{
    class Desktop
    {
        Pizzeria pizzeria = new Pizzeria();
        public void Menu()
        {
            bool swBool = true;
            do
            {
                Console.WriteLine(Environment.NewLine + "Пиццерия Pizza-Super-Puper приветствует вас!" + Environment.NewLine + Environment.NewLine + "Выберите действие: \n1. Сделать заказ \n2. Заказы в работе \n3. Забрать заказ \n0. Выход ");
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
}
