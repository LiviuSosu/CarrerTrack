using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Exceptions
{
    public class UserPasswordDoesNotMatchException : Exception
    {
        public UserPasswordDoesNotMatchException(string message)
        : base(message)
        {

        }
    }
}
