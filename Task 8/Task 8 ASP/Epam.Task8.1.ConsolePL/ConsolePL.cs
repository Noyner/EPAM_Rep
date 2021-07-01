using System;
using Epam.Task8._1.BLL;
using Epam.Task8._1.Common.Entities;
using Epam.Users.Dependences;

namespace Epam.Task8._1.PL.ConsolePL
{
    public class ConsolePL
    {
        static void Main(string[] args)
        {
            var bll = DependencyResolver.Instance.UserLogic;
            var bll2 = DependencyResolver.Instance.AwardLogic;
           

            //bll.AddUser(new User("Mark", DateTime.Parse("1998.8.6"), 22, Guid.NewGuid()));
            //bll.AddUser(new User("Bruno", DateTime.Parse("1993.3.6"), 27, Guid.NewGuid()));
          
            bll.AllUser();

            bll2.AddAward(new Award("Награда за упорство", Guid.NewGuid()));
            bll2.AllAward();

            //bll.RemoveUser(Guid.Parse("5e000bab-e8e5-4a51-b40d-dca47744fcd2"));


        }
    }
}
