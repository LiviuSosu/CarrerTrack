using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Read.Interface
{
    public interface IAppReadUserService : IAppReadServiceBase<User>
    {
        bool IsLoginSuccessfull(User user);
        User GetUserByEmail(string email); 
    }
}
