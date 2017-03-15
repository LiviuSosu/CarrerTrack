using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserNotes { get; set; }
        public string Source { get; set; }


        public int UserId { get; set; }
        public virtual User user { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
