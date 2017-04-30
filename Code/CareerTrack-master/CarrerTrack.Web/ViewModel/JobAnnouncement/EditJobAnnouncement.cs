using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarrerTrack.Web.ViewModel.JobAnnouncement
{
    public class EditJobAnnouncement
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public string Rewards { get; set; }

        [Required(ErrorMessage = "Source is required")]
        [MaxLength(100, ErrorMessage = "The source can have up to 100 characters")]
        [MinLength(2, ErrorMessage = "The source must have at least 2 characters")]
        public string Source { get; set; }
        public string Contact { get; set; }

        [Required(ErrorMessage = "Please select at least one skill")]
        [Display(Name = "Selected skills")]
        public IEnumerable<int> SelectedSkill { get; set; }

        public IEnumerable<SelectListItem> Skills { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Location")]
        public int LocationId { get; set; }
        public IEnumerable<SelectListItem> Location { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Role")]
        public int RoleId { get; set; }
        public IEnumerable<SelectListItem> Role { get; set; }

        //[Required(ErrorMessage = "*")]
        //[Display(Name = "Company")]
        //public int CompanyId { get; set; }
        //public IEnumerable<SelectListItem> Company { get; set; }

        public int UserId { get; set; }
        public virtual User user { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
    }
}