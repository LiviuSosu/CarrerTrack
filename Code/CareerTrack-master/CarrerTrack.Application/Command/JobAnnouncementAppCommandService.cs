using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Command.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Command
{
    public class JobAnnouncementAppCommandService : AppCommandServiceBase<JobAnnouncement>, IAppCommandJobAnnouncementService
    {
        private readonly ICommandJobAnnouncementService _commandJobAnnouncementService;

        public JobAnnouncementAppCommandService(ICommandJobAnnouncementService commandJobAnnouncementService)
            :base(commandJobAnnouncementService)
        {
            _commandJobAnnouncementService = commandJobAnnouncementService;
        }

        public void AddJobAnnouncement(JobAnnouncement jobAnnouncemnet)
        {
            _commandJobAnnouncementService.AddJobAnnouncement(jobAnnouncemnet);
        }

        public void UpdateJobAnnouncement(JobAnnouncement jobAnnouncement)
        {
            _commandJobAnnouncementService.UpdateJobAnnouncement(jobAnnouncement);
        }

        public void RemoveJobAnnouncemnet(int jobAnnouncementId)
        {
            _commandJobAnnouncementService.RemoveJobAnnouncemnet(jobAnnouncementId);
        }
    }
}
