using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Exceptions;
using CarrerTrack.Domain.Interfaces.Command;
using CarrerTrack.Domain.Interfaces.Command.Services;
using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Services
{
    public class CommandUserService : CommandServiceBase<User>, ICommandUserService
    {
        private readonly ICommandUserRepository _commandRepository;

        public CommandUserService(ICommandUserRepository commandRepository)
            :base(commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public void RegisterUser(User user, string confirmPassword)
        {
            if (user.Password != confirmPassword)
            {
                throw new UserPasswordDoesNotMatchException("User could not be registered. The provided password does not match.");
            }
            else
            {
                var crypto = new PBKDF2();
                user.Password = crypto.Compute(user.Password);

                user.PasswordSalt = crypto.Salt;
                //user.IsActive = true;

                _commandRepository.Add(user);
            }
        }     
    }
}
