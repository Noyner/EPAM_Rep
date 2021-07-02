using Epam.UsersAwards.Entities;
using System.Collections.Generic;
using System;

namespace Epam.UsersAwardsDAL.Interfaces
{
    public interface IAwardDAO
    {
        void AddAward(Award award);

        IList<Award> AllAward();

        void GiveAward(Guid userId, Guid awardId);
    }
}
