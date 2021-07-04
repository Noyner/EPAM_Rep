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

        public void RemoveAward(Guid id)
        {
            _awardDAO.DeleteAward(id);
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

        public void EditAward(Guid id, string newTitle)
        {
            _awardDAO.EditAward(id, newTitle);
        }
    }
}
