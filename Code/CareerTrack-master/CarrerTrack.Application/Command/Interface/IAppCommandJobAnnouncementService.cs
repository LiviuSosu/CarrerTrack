using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Command.Interface
{
    public interface IAppCommandJobAnnouncementService : IAppCommandServiceBase<JobAnnouncement>
    {
        /*
            Since a Job Announcement has one or multiple skills (one-to-many Relationship between JobAnnouncement and Skills) the methods bellow required complex implementation that is not present on the methods inherited from the IAppCommandServiceBase<JobAnnouncement>.
        */

        void AddJobAnnouncement(JobAnnouncement jobAnnouncemnet);

        void UpdateJobAnnouncement(JobAnnouncement jobAnnouncement);

        void RemoveJobAnnouncemnet(int jobAnnouncementId);
    }
}
