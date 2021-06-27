using System;

namespace Epam.Task8._1.Entities
{
    public class User
    {
        public User(string name, DateTime dateOfBirth, int age)
        {
            ID = Guid.NewGuid();
            Name = name;
            DateOfBirth = dateOfBirth;
            Age = age;
        }

        public Guid ID { get; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }
    }
}
