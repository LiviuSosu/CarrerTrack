using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Command;
using CarrerTrack.Domain.Interfaces.Command.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Services.Command
{
    public class CommandJobAnnouncementService : CommandServiceBase<JobAnnouncement>, ICommandJobAnnouncementService
    {
        private readonly ICommandJobAnnouncementRepository _commandRepository;

        public CommandJobAnnouncementService(ICommandJobAnnouncementRepository commandRepository)
            :base(commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public void AddJobAnnouncement(JobAnnouncement jobAnnouncemnet)
        {
            _commandRepository.AddJobAnnouncement(jobAnnouncemnet);
        }

        public void UpdateJobAnnouncement(JobAnnouncement jobAnnouncement)
        {
            _commandRepository.UpdateJobAnnouncement(jobAnnouncement);
        }

        public void RemoveJobAnnouncemnet(int jobAnnouncementId)
        {
            _commandRepository.RemoveJobAnnouncemnet(jobAnnouncementId);
        }
    }
}
