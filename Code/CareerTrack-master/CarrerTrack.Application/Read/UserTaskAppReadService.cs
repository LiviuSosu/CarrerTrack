using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Read
{
    public class UserTaskAppReadService : AppReadServiceBase<UserTask>, IAppReadUserTaskService
    {
        private readonly IReadUserTaskService _commandUserService;

        public UserTaskAppReadService(IReadUserTaskService commandUserService)
            :base(commandUserService)
        {
            _commandUserService = commandUserService;
        }

        public IEnumerable<UserTask> GetUserTasks(int userId)
        {
            return _commandUserService.GetUserTasks(userId);
        }
    }
}
