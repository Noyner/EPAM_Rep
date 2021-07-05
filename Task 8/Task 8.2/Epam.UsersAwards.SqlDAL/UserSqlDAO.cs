using System;
using Epam.UsersAwards.Entities;
using Epam.UsersAwardsDAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersAwards.SqlDAL
{
    public class UserSqlDAO : IUserDAO
    {
        public const string JSON_FILES_PATH = @"C:\Users\Sgt.Pepper\Desktop\Study\EPAM\EPAM_Rep\Task 8\ask 8.2\Users\";
        public void AddUser(User user)
        {
            // TODO: Add Note to my SQL Database
        }

        public void DeleteUser(Guid id)
        {
            // TODO: Delete user from SQL Database

        }

        public IList<User> AllUsers()
        {
            throw new NotImplementedException("0");
        }

        public void EditUser(Guid id, string newName, DateTime newDateTimeOfBirth, int newAge)
        {
            // TODO: Edit user from SQL Database
        }

        private string GetUserById(Guid id) => JSON_FILES_PATH + id + ".json";
    }
}
