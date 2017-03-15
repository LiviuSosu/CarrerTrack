using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarrerTrack.Web.Model
{
    public class InterviewQuestion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Question content is required")]
        [Display(Name ="Question")]
        [MinLength(30, ErrorMessage ="The minimum lenght for question is 30 characters")]
        [MaxLength(1000,ErrorMessage ="Question can have up to 1000 characters")]
        public string QuestionContent { get; set; }

        [Display(Name = "Answer")]
        [MaxLength(1000, ErrorMessage = "Question can have up to 1000 characters")]
        public string AnswerContent { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public IEnumerable<SelectListItem> Company { get; set; }
    }
}