using System;
using Epam.Task8._1.Common.Entities;

namespace Epam.Users.BLL.Interfaces
{
    public interface IAwardLogic
    {
        void AddAward(Award award);

        void AllAward();

        void GiveAward(Guid userId, Guid awardId);
    }
}
