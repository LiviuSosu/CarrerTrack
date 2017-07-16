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
        /// <summary>
        /// returns true if the User has succesfully logged in.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool IsLoginSuccessfull(User user);
        /// <summary>
        /// If the user succesfully logs in, it will update the flag IsActive to true
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool IsLoginSuccessfullForAccountActivation(User user);

        /// <summary>
        /// Returns a user given an email adress. If the user is not found it will return null
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        User GetUserByEmail(string email); 
    }
}
