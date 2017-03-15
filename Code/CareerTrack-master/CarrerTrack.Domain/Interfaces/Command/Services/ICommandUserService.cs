﻿using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Interfaces.Command.Services
{
    public interface ICommandUserService : ICommandServiceBase<User>
    {
        void RegisterUser(User user, string confirmPassword);
    }
}
