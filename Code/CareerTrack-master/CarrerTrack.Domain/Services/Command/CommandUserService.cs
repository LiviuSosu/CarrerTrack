using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Exceptions;
using CarrerTrack.Domain.Interfaces.Command;
using CarrerTrack.Domain.Interfaces.Command.Services;
using SimpleCrypto;
using System;
using System.Linq;
using System.Net.Mail;
using System.Text;

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
                throw new UserPasswordDoesNotMatchException("The provided password does not match.");
            }
            else
            {
                var crypto = new PBKDF2();
                user.Password = crypto.Compute(user.Password);
                user.PasswordSalt = crypto.Salt;

                _commandRepository.RegisterUser(user);
            }
        }

        public void ChangePassword(User user,string oldPassword, string newPassword, string cofirmPassword)
        {
            if (newPassword != cofirmPassword)
            {
                throw new UserPasswordDoesNotMatchException("The provided password does not match.");
            }
            else
            {
                var crypto = new PBKDF2();
                if(user.Password==crypto.Compute(oldPassword, user.PasswordSalt))
                {
                    user.Password = crypto.Compute(newPassword);
                    user.PasswordSalt = crypto.Salt;

                    if (user.IsActive)
                    {
                        _commandRepository.Update(user);
                    }
                    else
                    {
                   //     ILogging logger = new Logging();
                     //   logger.LogDeactivatedUsersAttemptsToChangePassword(user.UserId);
                        throw new UserNotAuthorizedToChangePassword("Ths account is locked.");
                    }
                }
                else
                {
                    throw new UserNotAuthorizedToChangePassword("Your old password is not correct.");
                }
            }
        }

        public void DeactivateAccount(User user)
        {
            user.IsActive = false;
            _commandRepository.Update(user);
        }

        public void ActivateAccount(User user)
        {
            user.IsActive = true;
            _commandRepository.Update(user);
        }

        public void ForgotPassword(User user)
        {
            string generatedString = RandomString(10);

            ///Aspnet_regiis.exe
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("carrer.track.adm@gmail.com", "SecretPassword");
            MailMessage mm = new MailMessage("carrer.track.adm@gmail.com", user.Email, "Carrer track", "Your new password is "+ generatedString);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);

            SimpleCrypto.PBKDF2 crypto = new PBKDF2();
            user.Password = crypto.Compute(generatedString,user.PasswordSalt);
            _commandRepository.Update(user);
        }

        private string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
