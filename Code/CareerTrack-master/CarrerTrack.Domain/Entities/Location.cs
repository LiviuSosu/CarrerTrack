using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }

        public string City { get; set; }
        public string Details { get; set; }

        public int UserId { get; set; }
        public virtual User user { get; set; }

        public IEnumerable<JobAnnouncement> JobAnnouncements { get; set; }
    }
}
