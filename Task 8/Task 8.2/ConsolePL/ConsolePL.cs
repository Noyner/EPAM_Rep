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
            //bll.AddUser(new User("Bruno", DateTime.Parse("1993.3.6"), 27, Guid.NewGuid()));

            //bll2.GiveAward(Guid.Parse("b3813738-cfb1-41b0-9a04-40eeff0b6cf4"), Guid.Parse("e0ae15c2-a3be-4430-9794-1747b3404e04"));
            //bll2.GiveAward(Guid.Parse("2f1df8d9-b88c-4db5-a8a7-fb95ad24e834"), Guid.Parse("e0ae15c2-a3be-4430-9794-1747b3404e04"));

            bll.AllUser();
            //bll2.AddAward(new Award("Награда за упорство", Guid.NewGuid()));
            //bll2.AddAward(new Award("Тестовая награда", Guid.NewGuid()));
            bll2.AllAward();
            Console.ReadLine();

            //bll.EditUser(Guid.Parse("a605f419-db1f-4ee4-83be-c8de3dd1e550"), "Markus", DateTime.Parse("1998.8.6"), 22);

            //bll.RemoveUser(Guid.Parse("5e000bab-e8e5-4a51-b40d-dca47744fcd2"));
        }
    }
}



