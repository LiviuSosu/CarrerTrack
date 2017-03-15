using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrerTrack.Web.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Title")]
        [MinLength(5, ErrorMessage = "Title must have at least 5 characters")]
        public string BookTitle { get; set; }

        public string Author { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public string Status { get; set; }
        public string Description { get; set; }

        [ScaffoldColumn(false)]
        public HttpPostedFileBase File { get; set; }

        [Key]
        public int UserId { get; set; }
    }
}