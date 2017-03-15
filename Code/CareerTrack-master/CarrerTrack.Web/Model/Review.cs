using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrerTrack.Web.Model
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Review content is required")]
        [Display(Name = "Content")]
        [MinLength(5, ErrorMessage ="Review content must have at least 5 characters")]
        [MaxLength(1000, ErrorMessage = "Review content can have up to 1000 characters")]
        public string Content { get; set; }

        [Display(Name ="User notes")]
        public string UserNotes { get; set; }

        [Required(ErrorMessage = "Review source is required")]
        [Display(Name = "Source")]
        [MinLength(5, ErrorMessage = "Review source must have at least 5 characters")]
        [MaxLength(100, ErrorMessage = "Review source can have up to 1000 characters")]
        public string Source { get; set; }

        [Key]
        public int UserId { get; set; }
        [Key]
        public int CompanyId { get; set; }
    }
}