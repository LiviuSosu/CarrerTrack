using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Interfaces.Read.Services
{
    public interface IReadUserService : IReadServiceBase<User>
    {
        bool IsLoginSuccessfull(User user);
        User GetUserByEmail(string email);
    }
}
