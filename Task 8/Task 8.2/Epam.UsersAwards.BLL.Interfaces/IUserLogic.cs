using System;
using Epam.UsersAwards.Entities;
using System.Collections.Generic;

namespace Epam.UsersAwards.BLL.Interfaces
{
    public interface IUserLogic
    {
        User AddUser(User user);

        void RemoveUser(Guid id);

        IEnumerable <User> AllUsers();

        void EditUser(Guid id, string newName, DateTime newDateTime, int newAge);
    }
}
