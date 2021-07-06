using System;
using Epam.UsersAwards.Entities;
using System.Collections.Generic;
using Epam.UsersAwardsDAL.Interfaces;

namespace Epam.UsersAwards.SqlDAL
{
    public class AwardSqlDAO : IAwardDAO
    {
        public const string JSON_FILES_PATH = @"C:\Users\Sgt.Pepper\Desktop\Study\EPAM\EPAM_Rep\Task 8\Task 8.2\Awards\";
        public void AddAward(Award award)
        {
            // TODO: Add Note to my SQL Database
        }

        public IEnumerable<Award> AllAwards()
        {
            return null;
        }

        public void DeleteAward(Guid id)
        {
            // TODO: Delete award from SQL Database

        }

        public void EditAward(Guid id, string newTitle)
        {

        }

        public void GiveAward(Guid userId, Guid awardId)
        {

        }
    }
}
