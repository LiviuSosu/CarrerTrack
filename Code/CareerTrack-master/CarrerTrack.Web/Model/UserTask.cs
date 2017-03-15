using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrerTrack.Web.Model
{
    public class UserTask
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Task name")]
        [Required]
        [MinLength(3,ErrorMessage ="The minimum length for this field is 3 charecters")]
        [MaxLength(100, ErrorMessage = "The maximum lenght for this field is 100 charecters")]
        public string Name { get; set; }
        public string Description { get; set; }

        public string Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date to complete")]
        public DateTime? ToComplete { get; set; }

        [Range(minimum: 0, maximum: 3, ErrorMessage = "The priority must be between 0 and 3")]
        [Required]
        public int Priority { get; set; }

        [Key]
        public int UserId { get; set; }
        //public virtual User user { get; set; }
    }
}