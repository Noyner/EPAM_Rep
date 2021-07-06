using System;
using Epam.UsersAwards.Entities;
using Epam.UsersAwards.BLL.Interfaces;
using Epam.UsersAwardsDAL.Interfaces;
using System.Collections.Generic;

namespace Epam.UsersAwards.BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserDAO _userDAO;

        public UserLogic(IUserDAO userDao)
        {
            _userDAO = userDao;
        }
        public User AddUser(User user)
        {
            _userDAO.AddUser(user);
            return user;
        }

        public void RemoveUser(Guid id)
        {
            _userDAO.DeleteUser(id);
        }

        public IEnumerable<User> AllUsers()
        {
            return _userDAO.AllUsers();
        }

        public void EditUser(Guid id, string newName, DateTime newDateTime, int newAge)
        {
            _userDAO.EditUser(id, newName, newDateTime, newAge);
        }
    }
}
