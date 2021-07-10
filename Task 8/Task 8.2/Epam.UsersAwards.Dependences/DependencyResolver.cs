using System;
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

        public static DependencyResolver GetInstance()
        {
            if(_instance == null)
            {
                _instance = new DependencyResolver();
            }

            return _instance;
        }
        #endregion

        public IUserDAO UserDAO => new UserSqlDAO();

        public IUserLogic UserLogic => new UserLogic(UserDAO);

        public IAwardDAO AwardDAO => new AwardSqlDAO();

        public IAwardLogic AwardLogic => new AwardLogic(AwardDAO);
    }
}
