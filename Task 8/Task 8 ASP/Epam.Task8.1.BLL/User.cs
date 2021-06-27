using System;
using System.Collections.Generic;

namespace Epam.Task8._1.BLL
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
    }
}
