﻿using System;
using Epam.UsersAwardsDAL.Interfaces;
using Epam.UsersAwards.JsonDAL;
using Epam.UsersAwards.SqlDAL;
using Epam.UsersAwards.BLL.Interfaces;
using Epam.UsersAwards.BLL;

namespace Epam.UsersAwards.Dependences
{
    public class DependencyResolver
    {
        #region SINGLETONE
        private static DependencyResolver _instance;

        public static DependencyResolver Instance => new DependencyResolver();
        #endregion

        public IUserDAO UserDAO => new UserJsonDAO();

        public IUserLogic UserLogic => new UserLogic(UserDAO);

        public IAwardDAO AwardDAO => new AwardJsonDAO();

        public IAwardLogic AwardLogic => new AwardLogic(AwardDAO);
    }
}
