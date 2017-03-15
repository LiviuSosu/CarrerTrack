using CarrerTrack.Data.Context;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Command;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarrerTrack.Data.Repositories.Command
{
    public class CommandJobAnnouncementRepository : CommandRepositoryBase<JobAnnouncement>, ICommandJobAnnouncementRepository
    {
        public void AddJobAnnouncement(JobAnnouncement jobAnnouncemnet)
        {
            JobAnnouncement _jobAnnouncement = new JobAnnouncement();
            _jobAnnouncement.Contact = jobAnnouncemnet.Contact;
            _jobAnnouncement.Content = jobAnnouncemnet.Content;
            _jobAnnouncement.Rewards = jobAnnouncemnet.Rewards;
            _jobAnnouncement.Source = jobAnnouncemnet.Source;
            _jobAnnouncement.UserId = jobAnnouncemnet.UserId;
            _jobAnnouncement.RoleId = jobAnnouncemnet.RoleId;
            _jobAnnouncement.LocationId = jobAnnouncemnet.LocationId;
            _jobAnnouncement.CompanyId = jobAnnouncemnet.CompanyId;

            _jobAnnouncement.Skills = new List<Skill>();
            foreach (var skill in jobAnnouncemnet.Skills)
            {
                _jobAnnouncement.Skills.Add(db.Skills.Find(skill.Id));
            }

            db.JobAnnouncements.Add(_jobAnnouncement);
            db.SaveChanges();
        }

        public void UpdateJobAnnouncement(JobAnnouncement jobAnnouncement)
        {
            JobAnnouncement _jobAnnouncement = db.JobAnnouncements.Find(jobAnnouncement.Id);
            _jobAnnouncement.CompanyId = jobAnnouncement.CompanyId;
            _jobAnnouncement.Contact = jobAnnouncement.Contact;
            _jobAnnouncement.Content = jobAnnouncement.Content;
            _jobAnnouncement.Id = jobAnnouncement.Id;
            _jobAnnouncement.LocationId = jobAnnouncement.LocationId;
            _jobAnnouncement.Rewards = jobAnnouncement.Rewards;
            _jobAnnouncement.RoleId = jobAnnouncement.RoleId;
            _jobAnnouncement.Source = jobAnnouncement.Source;
            _jobAnnouncement.UserId = jobAnnouncement.UserId;

            _jobAnnouncement.Skills.Clear();
            foreach (var skill in jobAnnouncement.Skills)
            {
                _jobAnnouncement.Skills.Add(db.Skills.Find(skill.Id));
            }
            db.Entry<JobAnnouncement>(_jobAnnouncement).CurrentValues.SetValues(_jobAnnouncement);
            db.SaveChanges();
        }

        public void RemoveJobAnnouncemnet(int jobAnnouncementId)
        {
            var jobAnnouncement = db.JobAnnouncements.Find(jobAnnouncementId);

            jobAnnouncement.Skills.Clear();
            db.JobAnnouncements.Remove(jobAnnouncement);
            db.SaveChanges();
        }
    }
}
