using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrerTrack.Web.Model
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="City name is required")]
        [Display(Name ="Location")]
        [MinLength(2,ErrorMessage = "Minimum lenghth for location is 2 characters")]
        [MaxLength(30, ErrorMessage = "Minimum lenghth for location is 30 characters")]
        public string City { get; set; }

        [Display(Name = "Location details")]
        [MaxLength(1000, ErrorMessage = "Minimum lenghth for location details is 1000 characters")]
        public string Details { get; set; }

        [Key]
        public int UserId { get; set; }
    }
}