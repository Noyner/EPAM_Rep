using System;
using Epam.Task8._1.Common.Entities;
using System.Collections.Generic;
using System.Text;

namespace Epam.UsersDAL.Interfaces
{
    public interface IUserDAO
    {
        void AddUser(User user);

        void DeleteUser(Guid id);

        void EditUser(Guid id, string newName, DateTime newDateTimeOfBirth, int newAge);

        void AllUsers();
    }
}
