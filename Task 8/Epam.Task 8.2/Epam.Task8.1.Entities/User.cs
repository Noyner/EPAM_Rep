using System;
using System.Collections.Generic;

namespace Epam.Task8._2.Common.Entities
{
    public class User
    {
        public User(string name, DateTime dateOfBirth, int age, Guid id)
        {
            ID = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Age = age;
            Awards = new List<Award>();
        }

        public Guid ID { get; private set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public void Edit(string newName, DateTime newDateOfBirth, int newAge)
        {
            if (newName == null)
                throw new ArgumentNullException("str", "Name cannot be null");

            Name = newName;
            DateOfBirth = newDateOfBirth;
            Age = newAge;
        }

        public void GetAward(Award award)
        {
            Awards.Add(award);
        }

        public ICollection<Award> Awards { get; set; }

    }
}
