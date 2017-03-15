using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrerTrack.Web.Model
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Skill")]
        [Required(ErrorMessage ="Skill name is required")]
        [MaxLength(30, ErrorMessage = "Skill name can have up to 30 characters")]
        public string Name { get; set; }
    }
}