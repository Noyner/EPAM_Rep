using Epam.UsersAwards.Entities;
using System.Collections.Generic;
using System;

namespace Epam.UsersAwardsDAL.Interfaces
{
    public interface IAwardDAO
    {
        void AddAward(Award award);

        void DeleteAward(Guid id);

        void EditAward(Guid id, string newTitle);

        IList<Award> AllAward();

        void GiveAward(Guid userId, Guid awardId);

    }
}
