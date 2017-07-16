using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Interfaces.Read
{
    public interface IReadUserTaskRepository : IReadRepositoryBase<UserTask>
    {
        /// <summary>
        /// Get all UserTasks for a given user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<UserTask> GetUserTasks(int userId);
    }
}
