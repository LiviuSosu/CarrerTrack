using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Exceptions;
using System.Web;

namespace CarrerTrack.Web.Utils
{
    public static class LoggedUser
    {
        public static User GetLoggedUser(IAppReadUserService _userReadApp)
        {
            string userEmail = HttpContext.Current.User.Identity.Name;
            if (userEmail != null)
            {
                return _userReadApp.GetUserByEmail(userEmail);
            }
            else
            {
                throw new UserNotLoggedInException("The user is not logged in");
            }
        }

        public static int SelectedCompanyID { get; set; }
    }
}