using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersAwards.Entities
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

        public void EditAward(string newTitle)
        {
            if (newTitle == null)
                throw new ArgumentNullException("str", "Name cannot be null");

            Title = newTitle;
        }

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
