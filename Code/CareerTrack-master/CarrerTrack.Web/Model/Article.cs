using System.ComponentModel.DataAnnotations;

namespace CarrerTrack.Web.Model
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Display(Name ="Title")]
        [MinLength(5, ErrorMessage = "Title must have at least 5 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Link is required")]
        [Display(Name = "Link")]
        [MinLength(5, ErrorMessage = "Link must have at least 5 characters")]
        public string Link { get; set; }

        [Display(Name = "Source")]
        [MinLength(3, ErrorMessage = "Source must have at least 3 characters")]
        public string Source { get; set; }

        [Display(Name = "Is read")]
        public bool IsRead { get; set; }

        [Display(Name = "Notes")]
        [DataType(DataType.MultilineText)]
        [MaxLength(1000, ErrorMessage = "Notes field must have up to 1000 characters")]
        public string Notes { get; set; }

        public int UserId { get; set; }
    }
}