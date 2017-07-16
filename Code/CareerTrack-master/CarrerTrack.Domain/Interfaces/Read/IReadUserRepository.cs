using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Interfaces.Read
{
    public interface IReadUserRepository : IReadRepositoryBase<User>
    {
        /// <summary>
        /// Returns a user given an email adress. If the user is not found it will return null
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        User GetUserByEmail(string email);
    }
}
