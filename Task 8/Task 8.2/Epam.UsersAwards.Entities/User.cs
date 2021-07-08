using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersAwards.Entities
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

        public override string ToString()
        {
            string str = $"User:\n{Name} {Age} {DateOfBirth} {ID}\nAwards:\n";
            foreach (var aw in Awards)
            {
                str += "\t" + aw.ToString() + "\n";
            }
            return str;
        }
        public ICollection<Award> Awards { get; set; }
    }
}
