using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Entities
{
    public class JobAnnouncement
    {
        public int Id { get; set; }

        public DateTime DateAdded { get; set; }
        public string Content { get; set; }
        public string Rewards { get; set; }
        public string Source { get; set; }
        public string Contact { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        public int UserId { get; set; }
        public virtual User user { get; set; }

        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
