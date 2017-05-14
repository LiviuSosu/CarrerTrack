using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Command.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Command
{
    public class UserAppCommandService : AppCommandServiceBase<User>, IAppCommandUserService
    {
        private readonly ICommandUserService _commandUserService;

        public UserAppCommandService(ICommandUserService commandUserService)
            :base(commandUserService)
        {
            _commandUserService = commandUserService;
        }

        public void Register(User user, string confirmPassword)
        {
            _commandUserService.RegisterUser(user, confirmPassword);
        }

        public void ChangePassword(User user, string oldPassword, string newPassword, string confirmPassword)
        {
            _commandUserService.ChangePassword(user, oldPassword, newPassword, confirmPassword);
        }

        public void DeactivateAccount(User user)
        {
            _commandUserService.DeactivateAccount(user);
        }

        public void ForgotPassword(User user)
        {
            _commandUserService.ForgotPassword(user);
        }

        public void ActivateAccount(User user)
        {
            _commandUserService.ActivateAccount(user);
        }
    }
}
