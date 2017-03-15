using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Source { get; set; }
        public string Link { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public string Notes { get; set; }

        public int UserId { get; set; }
        public virtual User user { get; set; }
    }
}
