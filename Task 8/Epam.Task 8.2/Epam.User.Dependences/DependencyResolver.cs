using System;
using System.Collections.Generic;
using System.Text;
using Epam.UsersDAL.Interfaces;
using Epam.Task8._2.DAL.UserJsonDAO;
using Epam.Task8._2.DAL;
using Epam.Users.BLL.Interfaces;
using Epam.Task8._2.BLL;

namespace Epam.Users.Dependences
{
    public class DependencyResolver
    {
        #region SINGLETONE
        private static DependencyResolver _instance;

        public static DependencyResolver Instance => _instance ??= new DependencyResolver();
        #endregion

        public IUserDAO UserDAO => new UserJsonDAO();

        public IUserLogic UserLogic => new UserLogic(UserDAO);

        public IAwardDAO AwardDAO => new AwardsJsonDAO();

        public IAwardLogic AwardLogic => new AwardLogic(AwardDAO);
    }
}
