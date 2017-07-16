using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Interfaces.Command.Services
{
    public interface ICommandUserService : ICommandServiceBase<User>
    {
        /// <summary>
        /// This method is acctualy similar with CREATE. The difference is that we need to hash the password (using the library simplecrypto) and also to check if the password and the confirm password fields are the same.
        /// </summary>
        /// <param name="register"></param>
        /// <param name="confirmPassword"></param>
        void RegisterUser(User user, string confirmPassword);

        /// <summary>
        /// When changing the password it needs to make the necessary check if the user witll change his own password and not the password of an other user.
        /// Also the newPassword and the confirmPassword fields must match.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="confirmPassword"></param>
        void ChangePassword(User user,string oldPassword, string newPassword, string confirmPassword);

        /// <summary>
        /// Although it may seems like the DELETE method, it is performed a soft delete by setting the flaf isActive to false
        /// </summary>
        /// <param name="user"></param>
        void DeactivateAccount(User user);

        /// <summary>
        /// An email will be send with the new password which will be updated automathically on the database for the current user.
        /// </summary>
        /// <param name="user"></param>
        void ForgotPassword(User user);

        /// <summary>
        /// The flag IsActive will be set to q for the given user
        /// </summary>
        /// <param name="user"></param>
        void ActivateAccount(User user);
    }
}
