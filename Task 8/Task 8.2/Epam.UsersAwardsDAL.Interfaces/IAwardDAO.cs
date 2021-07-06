using Epam.UsersAwards.Entities;
using System.Collections.Generic;
using System;

namespace Epam.UsersAwardsDAL.Interfaces
{
    public interface IAwardDAO
    {
        Award AddAward(Award award);

        void DeleteAward(Guid id);

        void EditAward(Guid id, string newTitle);

        IEnumerable<Award> AllAwards();

        void GiveAward(Guid userId, Guid awardId);

    }
}
