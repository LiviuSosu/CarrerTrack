using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrerTrack.Web.Model
{
    public class JobAnnouncement
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public string Rewards { get; set; }

        public string Source { get; set; }

        public string Contact { get; set; }

        [Display(Name ="Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [Display(Name = "Location")]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        [Display(Name = "Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Display(Name = "Date added")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Required skills")]
        public IEnumerable<Skill> Skills { get; set; }

        public bool IsArchieved { get; set; }
    }
}