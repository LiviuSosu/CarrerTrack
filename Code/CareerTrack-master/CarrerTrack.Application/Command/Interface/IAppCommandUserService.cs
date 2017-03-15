using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Command.Interface
{
    public interface IAppCommandUserService : IAppCommandServiceBase<User>
    {
        void Register(User register, string confirmPassword);
    }
}
