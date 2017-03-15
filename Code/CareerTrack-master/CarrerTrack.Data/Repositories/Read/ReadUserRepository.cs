using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.Repositories.Read
{
    public class ReadUserRepository : ReadRepositoryBase<User>, IReadUserRepository
    {
        public User GetUserByEmail(string email)
        {
            var c = db.Users.ToList();
            return db.Users.Where(user => user.Email == email).FirstOrDefault();
        }
    }
}
