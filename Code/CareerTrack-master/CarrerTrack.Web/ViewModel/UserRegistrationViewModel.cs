using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrerTrack.Web.ViewModel
{
    public class UserRegistrationViewModel
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "First name")]
        [MinLength(3, ErrorMessage = "First name must be at least 3 characters length")]
        [MaxLength(50, ErrorMessage = "First name must be at least 50 characters length")]
        public string FirstName { get; set; }

        [Display(Name = "Middle name")]
        [MinLength(3, ErrorMessage = "First name must be at least 3 characters length")]
        [MaxLength(50, ErrorMessage = "First name must be at least 50 characters length")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Last name")]
        [MinLength(3, ErrorMessage = "Last name must be at least 3 characters length")]
        [MaxLength(50, ErrorMessage = "Last name must be at least 50 characters length")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Email")]
        [MinLength(5, ErrorMessage = "Email must be at least 3 characters length")]
        [MaxLength(50, ErrorMessage = "Email must be at least 50 characters length")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        [MinLength(5, ErrorMessage = "Password must be at least 3 characters length")]
        [MaxLength(20, ErrorMessage = "Password must be at least 20 characters length")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name ="Confirm password")]
        [MinLength(5, ErrorMessage = "Password must be at least 3 characters length")]
        [MaxLength(20, ErrorMessage = "Password must be at least 20 characters length")]
        public string ConfirmPassword { get; set; }

        [ScaffoldColumn(false)]
        public string PasswordSalt { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DateRegistered { get; set; }

        [ScaffoldColumn(false)]
        public bool IsActive { get; set; }
    }
}