using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Web.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage ="This field is requierd")]
        [Display(Name ="First name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "This field is requierd")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is requierd")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Old password")]
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters length")]
        [MaxLength(20, ErrorMessage = "Password must be at least 20 characters length")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "New password")]
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters length")]
        [MaxLength(20, ErrorMessage = "Password must be at least 20 characters length")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Confirm password")]
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters length")]
        [MaxLength(20, ErrorMessage = "Password must be at least 20 characters length")]
        public string ConfirmPassword { get; set; }
    }
}
