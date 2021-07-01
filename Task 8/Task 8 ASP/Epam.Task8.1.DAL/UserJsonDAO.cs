using Epam.Task8._1.Common.Entities;
using Epam.UsersDAL.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Epam.Task8._1.DAL.UserJsonDAO
{
    public class UserJsonDAO : IUserDAO
    {
        public const string JSON_FILES_PATH = @"C:\Users\Sgt.Pepper\Desktop\Study\EPAM\EPAM_Rep\Task 8\Task 8 ASP\Files\";
        public void AddUser(User user)
        {
            string json = JsonConvert.SerializeObject(user);
            File.WriteAllText(GetUserById(user.ID), json);
        }

        public void DeleteUser(Guid id)
        {
            if (File.Exists(GetUserById(id)))
            {
                File.Delete(GetUserById(id));
            }
            else
            {
                throw new FileNotFoundException(
                    string.Format("User with ID {} at path {1} isn`t created", id, JSON_FILES_PATH));
            }

        }

        public void AllUsers()
        {
            Console.WriteLine("User list: " + Environment.NewLine);
            string[] files = Directory.GetFiles(JSON_FILES_PATH, "*.json");
            foreach (string filename in files)
            {
                var jsonFull = File.ReadAllText(filename);
                Console.WriteLine(jsonFull);
            }
        }

        public void EditUser(Guid id, string newName, DateTime newDateTimeOfBirth, int newAge)
        {
            if (!File.Exists(GetUserById(id)))
            {
                throw new FileNotFoundException(
                    string.Format("File with name {0} at path {1} isn`t created!",
                    id, JSON_FILES_PATH));
            }

            User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(GetUserById(id)));
            user.Edit(newName, newDateTimeOfBirth, newAge);
            File.WriteAllText(GetUserById(id), JsonConvert.SerializeObject(user));
        }

        private string GetUserById(Guid id) => JSON_FILES_PATH + id + ".json";
    }
}
