using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrerTrack.Web.Model
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Role name")]
        [Required(ErrorMessage = "This field is required")]
        [MinLength(3, ErrorMessage ="The minimum length for this field is 3 characters")]
        [MaxLength(100, ErrorMessage = "The maximum length for this field is 100 characters")]
        public string Name { get; set; }

        [Display(Name = "Role description")]
        [MinLength(3, ErrorMessage = "The minimum length for this field is 3 characters")]
        [MaxLength(100, ErrorMessage = "The maximum length for this field is 100 characters")]
        public string Description { get; set; }

        
        public int UserId { get; set; }
    }
}