using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrerTrack.Web.Model
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [Display(Name = "Course name")]
        [MinLength(5, ErrorMessage = "Course name must have at least 5 characters")]
        [MaxLength(150, ErrorMessage = "Course name can have up to 150 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Course source is required")]
        [Display(Name = "Course source")]
        [MinLength(5, ErrorMessage = "Course source must have at least 5 characters")]
        [MaxLength(150, ErrorMessage = "Course source can have up to 150 characters")]
        public string Source { get; set; }

        [Display(Name = "Course link")]
        public string Link { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "User notes")]
        public string Notes { get; set; }

        [ScaffoldColumn(false)]
        public int UserId { get; set; }
    }
}