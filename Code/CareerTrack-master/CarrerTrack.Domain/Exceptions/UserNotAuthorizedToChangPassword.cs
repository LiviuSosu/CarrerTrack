using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Exceptions
{
    public class UserNotAuthorizedToChangePassword : Exception
    {
        public UserNotAuthorizedToChangePassword(string message)
        : base(message)
        {

        }
    }
}
