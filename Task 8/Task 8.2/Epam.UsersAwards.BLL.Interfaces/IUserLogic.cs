﻿using System;
using Epam.UsersAwards.Entities;
using System.Collections.Generic;

namespace Epam.UsersAwards.BLL.Interfaces
{
    public interface IUserLogic
    {
        void AddUser(User user);

        void RemoveUser(Guid id);

        IList <User> AllUser();

        void EditUser(Guid id, string newName, DateTime newDateTime, int newAge);
    }
}
