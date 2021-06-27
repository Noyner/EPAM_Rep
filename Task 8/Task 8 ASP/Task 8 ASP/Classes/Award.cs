using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_8_ASP
{
    public class Award
    {
        public int Id { get; set; }
        public string Title { get; set; }

        List<Award> awardList = new List<Award>();

        public Award(string title)
        {
            Title = title;
        }


        public void AddAward(Award award)
        {
            award.Id = awardList.Count;
            awardList.Add(award);
            Console.WriteLine("Награда {0} успешно добавлена", award.Title);
        }

        public void CountOfAward()
        {
            Console.WriteLine("Всего наград: {}", awardList.Count);
        }
    }
}