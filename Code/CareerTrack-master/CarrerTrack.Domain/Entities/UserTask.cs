using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Entities
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string Status { get; set; }
        public DateTime? ToComplete { get; set; }
        public int Priority { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
