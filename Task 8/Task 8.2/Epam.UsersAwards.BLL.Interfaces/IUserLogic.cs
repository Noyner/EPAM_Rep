using System;
using Epam.UsersAwards.Entities;

namespace Epam.UsersAwards.BLL.Interfaces
{
    public interface IUserLogic
    {
        void AddUser(User user);

        void RemoveUser(Guid id);

        void AllUser();

        void EditUser(Guid id, string newName, DateTime newDateTime, int newAge);
    }
}
