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
    public class ReadUserTaskService : ReadServiceBase<UserTask>, IReadUserTaskService
    {
        private readonly IReadUserTaskRepository _readRepository;

        public ReadUserTaskService(IReadUserTaskRepository readRepository)
            :base(readRepository)
        {
            _readRepository = readRepository;
        }

        public IEnumerable<UserTask> GetUserTasks(int userId)
        {
            return _readRepository.GetUserTasks(userId);
        }
    }
}
