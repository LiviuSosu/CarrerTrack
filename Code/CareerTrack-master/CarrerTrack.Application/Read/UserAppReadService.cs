using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Read
{
    public class UserAppReadService : AppReadServiceBase<User>, IAppReadUserService
    {
        private readonly IReadUserService _commandUserService;

        public UserAppReadService(IReadUserService commandUserService)
            :base(commandUserService)
        {
            _commandUserService = commandUserService;
        }

        public bool IsLoginSuccessfull(User user)
        {
            return _commandUserService.IsLoginSuccessfull(user);
        }

        public User GetUserByEmail(string email)
        {
            return _commandUserService.GetUserByEmail(email);
        }

        public bool IsLoginSuccessfullForAccountActivation(User user)
        {
            return _commandUserService.IsLoginSuccessfullForAccountActivation(user);
        }
    }
}
