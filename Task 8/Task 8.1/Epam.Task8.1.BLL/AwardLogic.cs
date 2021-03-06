﻿using System;
using System.Collections.Generic;
using Epam.Task8._1.Common.Entities;
using Epam.Users.BLL.Interfaces;
using Epam.UsersDAL.Interfaces;

namespace Epam.Task8._1.BLL
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
