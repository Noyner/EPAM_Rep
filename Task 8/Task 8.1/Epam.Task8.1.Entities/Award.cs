using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task8._1.Common.Entities
{
    public class Award
    {
        public Award(string title, Guid id)
        {
            ID = id;
            Title = title;
            Users = new List<User>();
        }

        public Guid ID { get; private set; }

        public string Title { get; set; }

        public void GiveAward(User user)
        {
            Users.Add(user);
        }

        public override string ToString()
        {
            return $"{Title} {ID}";
        }

        public ICollection<User> Users { get; set; }
    }
}
