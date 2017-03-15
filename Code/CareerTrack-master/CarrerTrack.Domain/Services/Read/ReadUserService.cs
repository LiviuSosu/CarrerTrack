using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read;
using CarrerTrack.Domain.Interfaces.Read.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Services.Read
{
    public class ReadUserService : ReadServiceBase<User>, IReadUserService
    {
        private readonly IReadUserRepository _readRepository;

        public ReadUserService(IReadUserRepository readRepository)
            :base(readRepository)
        {
            _readRepository = readRepository;
        }

        public bool IsLoginSuccessfull(User user)
        {
            bool isValid = false;
            var _user = _readRepository.GetUserByEmail(user.Email);
            if (_user != null)
            {
                var crypto = new SimpleCrypto.PBKDF2();
                if (_user.Password == crypto.Compute(user.Password, _user.PasswordSalt))
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        public User GetUserByEmail(string email)
        {
            return _readRepository.GetUserByEmail(email);
        }
    }
}
