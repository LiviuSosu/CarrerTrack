using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarrerTrack.Web.ViewModel.JobAnnouncement
{
    public class AddJobAnnouncementViewModel
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
        [Display(Name = "Selected Skills")]
        public IEnumerable<Model.Skill> JobAnnouncementRequiredSkills { get; set; }

        [Display(Name = "Location")]
        public IEnumerable<Location> Location { get; set; }

        [Display(Name = "Role")]
        public IEnumerable<Role> Role { get; set; }

        [Required(ErrorMessage = "Please choose a company")]
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }

        //for mapping
        public int RoleId { get; set; }
        public int LocationId { get; set; }
        public int UserId { get; set; }
    }
}