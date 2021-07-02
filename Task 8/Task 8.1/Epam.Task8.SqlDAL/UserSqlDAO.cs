using System;
using Epam.UsersDAL.Interfaces;
using Epam.Task8._1.Common.Entities;
using System.Collections.Generic;
using System.Text;

namespace Epam.Task8._1.DAL.UserSqlDAO
{
    public class UserSqlDAO : IUserDAO
    {
        public const string JSON_FILES_PATH = @"C:\Users\Sgt.Pepper\Desktop\Study\EPAM\EPAM_Rep\Task 8\Task 8.1\Files\";
        public void AddUser(User user)
        {
            // TODO: Add Note to my SQL Database
        }

        public void DeleteUser(Guid id)
        {
           // TODO: Delete user from SQL Database

        }

        public void AllUsers()
        {
            
        }

        public void EditUser(Guid id, string newName, DateTime newDateTimeOfBirth, int newAge)
        {
           // TODO: Edit user from SQL Database
        }

        private string GetUserById(Guid id) => JSON_FILES_PATH + id + ".json";
    }
}
