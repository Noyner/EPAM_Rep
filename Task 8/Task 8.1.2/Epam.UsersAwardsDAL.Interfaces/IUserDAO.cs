using System;
using Epam.UsersAwards.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersAwardsDAL.Interfaces
{
    public interface IUserDAO
    {
        void AddUser(User user);

        void DeleteUser(Guid id);

        void EditUser(Guid id, string newName, DateTime newDateTimeOfBirth, int newAge);

        IList<User> AllUsers();
    }
}
