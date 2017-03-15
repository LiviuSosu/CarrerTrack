using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrerTrack.Web.Model
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        [Display(Name = "Company name")]
        [MinLength(5, ErrorMessage = "Company name must have at least 5 characters")]
        [MaxLength(150, ErrorMessage = "Company name can have up to 150 characters")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Company size is required")]
        [Display(Name = "Size")]
        [MinLength(5, ErrorMessage = "Company size must have at least 5 characters")]
        [MaxLength(150, ErrorMessage = "Company size can have up to 150 characters")]
        public string Size { get; set; }

        [Display(Name = "Description")]
        [MaxLength(1000, ErrorMessage = "Description can have up to 1000 characters")]
        public string GeneralDescription { get; set; }

        [Display(Name = "Link")]
        [MaxLength(1000, ErrorMessage = "Link can have up to 150 characters")]
        public string Link { get; set; }
    }
}