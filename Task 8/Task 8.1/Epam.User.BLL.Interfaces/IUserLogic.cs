using System;
using Epam.Task8._1.Common.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.BLL.Interfaces
{
    public interface IUserLogic
    {

        void AddUser(User user);

        void RemoveUser(Guid id);

        void AllUser();

        void EditUser(Guid id, string newName, DateTime newDateTime, int newAge);

    }
}
