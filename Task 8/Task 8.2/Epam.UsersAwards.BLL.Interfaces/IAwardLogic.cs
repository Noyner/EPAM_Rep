using System;
using Epam.UsersAwards.Entities;

namespace Epam.UsersAwards.BLL.Interfaces
{
    public interface IAwardLogic
    {
        void AddAward(Award award);

        void AllAward();

        void GiveAward(Guid userId, Guid awardId);
    }
}
