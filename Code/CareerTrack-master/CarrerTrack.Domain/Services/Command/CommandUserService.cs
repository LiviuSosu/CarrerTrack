using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Exceptions;
using CarrerTrack.Domain.Interfaces.Command;
using CarrerTrack.Domain.Interfaces.Command.Services;
using SimpleCrypto;

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

        public void ForgotPassword(string userEmail)
        {
        }

        public void ChangePassword(string userEmail, string currentPassword, string newPassword)
        {
        }

        public void DeactivateAccount(string userEmail)
        {

        }
    }
}
