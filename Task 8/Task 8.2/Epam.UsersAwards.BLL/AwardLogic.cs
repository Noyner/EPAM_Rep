using System;
using Epam.UsersAwards.Entities;
using System.Collections.Generic;
using Epam.UsersAwards.BLL.Interfaces;
using Epam.UsersAwardsDAL.Interfaces;

namespace Epam.UsersAwards.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private IAwardDAO _awardDAO;

        public AwardLogic(IAwardDAO awardDao)
        {
            _awardDAO = awardDao;
        }

        public void AddAward(Award award)
        {
            _awardDAO.AddAward(award);
        }

        public IList<Award> AllAward()
        {
            return _awardDAO.AllAward();
        }

        public void GiveAward(Guid userId, Guid awardId)
        {
            _awardDAO.GiveAward(userId, awardId);
        }
    }
}
