using Epam.UsersAwards.Dependences;
using Epam.UsersAwards.Entities;
using System;

namespace Epam.UsersAwards.ConsolePL
{
    public class ConsolePL
    {
        static void Main(string[] args)
        {
            var bll = DependencyResolver.Instance.UserLogic;
            var bll2 = DependencyResolver.Instance.AwardLogic;


            //bll.AddUser(new User("Mark", DateTime.Parse("1998.8.6"), 22, Guid.NewGuid()));
            //bll.AddUser(new User("Yuri", DateTime.Parse("1993.3.6"), 27, Guid.NewGuid()));

            //bll2.GiveAward(Guid.Parse("da458099-3f2a-40a7-8995-11d66563c954"), Guid.Parse("70a4e768-e816-4ad2-98d7-43ec3e7d2fea"));
            //bll2.GiveAward(Guid.Parse("2f1df8d9-b88c-4db5-a8a7-fb95ad24e834"), Guid.Parse("e0ae15c2-a3be-4430-9794-1747b3404e04"));

            //bll.AddUser(new User("Mark", DateTime.Parse("1998.8.6"), 22, Guid.NewGuid()));
            foreach(var item in bll.AllUsers())
            {
                Console.WriteLine(item);
            }
           bll.RemoveUser(Guid.Parse("0860a175-85af-4e1e-81b4-d19b937d3d6d"));
            foreach (var item in bll.AllUsers())
            {
                Console.WriteLine(item);
            }
            //bll2.AddAward(new Award("Тестовая награда", Guid.NewGuid()));
            Console.ReadLine();

            //bll.EditUser(Guid.Parse("a605f419-db1f-4ee4-83be-c8de3dd1e550"), "Markus", DateTime.Parse("1998.8.6"), 22);

            //bll.RemoveUser(Guid.Parse("5e000bab-e8e5-4a51-b40d-dca47744fcd2"));
        }
    }
}



