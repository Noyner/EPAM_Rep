using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_8_ASP
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public int Age { get; set; }

        public User(string name, string dateOfBirth, int age)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Age = age;
        }

        List<User> userList = new List<User>();

        public void AddUser(User user)
        {
            user.Id = userList.Count;
            userList.Add(user);
            Console.WriteLine("Пользователь {0} успешно добавлен", user.Name);
        }

        public void DeleteUser(User user)
        {
            userList.Remove(user);
            Console.WriteLine("Пользователь {0} успешно удалён", user.Name);
        }

        public void AllUsers()
        {
            for (int i = 0; i<=userList.Count; i++)
            {
                Console.WriteLine("User #{0} - {1}", i, userList[i]);
            }
        }
    }
}