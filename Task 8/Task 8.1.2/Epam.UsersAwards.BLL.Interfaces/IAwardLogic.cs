﻿using System;
using Epam.UsersAwards.Entities;
using System.Collections.Generic;

namespace Epam.UsersAwards.BLL.Interfaces
{
    public interface IAwardLogic
    {
        void AddAward(Award award);

        void RemoveAward(Guid id);

        IList<Award> AllAward();

        void GiveAward(Guid userId, Guid awardId);

        void EditAward(Guid id, string newTitle);
    }
}
