using System;
using System.Collections.Generic;
using System.Linq;
using Epam.Task8._1.Common.Entities;
using System.Threading.Tasks;

namespace Epam.UsersDAL.Interfaces
{
    public interface IAwardDAO
    {
        void AddAward(Award award);

        void AllAward();

        void GiveAward(Guid userId, Guid awardId);
    }
}
