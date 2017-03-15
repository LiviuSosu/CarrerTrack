using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Size { get; set; }
        public string GeneralDescription { get; set; }
        public string Link { get; set; }

        public int UserId { get; set; }
        public virtual User user { get; set; }

        public IEnumerable<JobAnnouncement> JobAnnouncements { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}
