using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Interfaces.Command
{
    public interface ICommandJobAnnouncementRepository : ICommandRepositoryBase<JobAnnouncement>
    {
         void AddJobAnnouncement(JobAnnouncement jobAnnouncemnet);

         void UpdateJobAnnouncement(JobAnnouncement jobAnnouncement);

        void RemoveJobAnnouncemnet(int jobAnnouncementId);
    }
}
