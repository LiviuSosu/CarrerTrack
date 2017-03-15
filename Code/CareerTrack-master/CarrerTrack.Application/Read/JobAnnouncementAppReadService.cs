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
    public class JobAnnouncementAppReadService : AppReadServiceBase<JobAnnouncement>, IAppReadJobAnnouncementService
    {
        private readonly IReadJobAnnouncementService _commandJobAnnouncementService;

        public JobAnnouncementAppReadService(IReadJobAnnouncementService commandJobAnnouncementService)
            :base(commandJobAnnouncementService)
        {
            _commandJobAnnouncementService = commandJobAnnouncementService;
        }
    }
}
