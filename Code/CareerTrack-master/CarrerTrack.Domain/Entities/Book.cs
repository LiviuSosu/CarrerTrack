using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public string ContentType { get; set; }
        public byte[] Content { get; set; }

        public int UserId { get; set; }
        public virtual User user { get; set; }
    }
}
