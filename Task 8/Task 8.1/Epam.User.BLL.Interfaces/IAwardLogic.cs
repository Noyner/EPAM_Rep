using System;
using System.Collections.Generic;
using Epam.Task8._1.Common.Entities;

namespace Epam.Users.BLL.Interfaces
{
    public interface IAwardLogic
    {
        void AddAward(Award award);

        IList<Award> AllAward();

        void GiveAward(Guid userId, Guid awardId);
    }
}
