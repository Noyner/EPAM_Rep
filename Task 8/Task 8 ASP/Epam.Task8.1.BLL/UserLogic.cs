using Epam.Task8._1.Common.Entities;
using Epam.Users.BLL.Interfaces;
using Epam.UsersDAL.Interfaces;
using System;

namespace Epam.Task8._1.BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserDAO _userDAO;

        public UserLogic(IUserDAO userDao)
        {
            _userDAO = userDao;
        }
        public void AddUser(User user)
        {
            _userDAO.AddUser(user);
        }

        public void RemoveUser(Guid id)
        {
            _userDAO.DeleteUser(id);
        }

        public void AllUser()
        {
            _userDAO.AllUsers();
        }

        public void EditUser(Guid id, string newName, DateTime newDateTime, int newAge)
        {
            _userDAO.EditUser(id, newName, newDateTime, newAge);
        }
    }
}
