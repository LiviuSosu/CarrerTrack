using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.Repositories.Read
{
    public class ReadUserTaskRepository : ReadRepositoryBase<UserTask>, IReadUserTaskRepository
    {
        public IEnumerable<UserTask> GetUserTasks(int userId)
        {
            var user = db.Users.Find(userId);
            return db.UserTasks.Where(ut=>ut.UserId==userId);
        }
    }
}
