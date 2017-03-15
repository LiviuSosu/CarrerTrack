using CarrerTrack.Data.Context;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Command;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.Repositories.Command
{
    public class CommandUserRepository : CommandRepositoryBase<User>, ICommandUserRepository
    {
        //public void RegisterUser(User user)
        //{
        //    //throw new NotImplementedException("Register user nu este implementata");
        //}
    }
}
