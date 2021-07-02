using Epam.UsersAwards.Entities;
using System;

namespace Epam.UsersAwardsDAL.Interfaces
{
    public interface IAwardDAO
    {
        void AddAward(Award award);

        void AllAward();

        void GiveAward(Guid userId, Guid awardId);
    }
}
