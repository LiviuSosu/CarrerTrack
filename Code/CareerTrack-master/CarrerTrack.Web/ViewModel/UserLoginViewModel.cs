using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrerTrack.Web.ViewModel
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}