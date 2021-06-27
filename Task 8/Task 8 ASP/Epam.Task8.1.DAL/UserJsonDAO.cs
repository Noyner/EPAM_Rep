using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Epam.Task8._1.Entities;
using Newtonsoft.Json;

namespace Epam.Task8._1.DAL
{
    public class UserJsonDAO
    {
        public const string JSON_FILES_PATH = @"C:\Users\Sgt.Pepper\Desktop\Study\EPAM\EPAM_Rep\Task 8\Task 8 ASP\Files";
        public void AddUser(User user)
        {
            string json = JsonConvert.SerializeObject(user);
            using (var stream = File.Create(JSON_FILES_PATH + user.ID));

            //Console.WriteLine("Пользователь {0} успешно добавлен", user.Name);
        }

        public void DeleteUser(Guid ID)
        {
           // userList.Remove(ID);
           // Console.WriteLine("Пользователь {0} успешно удалён", user.Name);
        }

        public void AllUsers()
        {
            //Console.WriteLine(userList);
        }
    }
}
