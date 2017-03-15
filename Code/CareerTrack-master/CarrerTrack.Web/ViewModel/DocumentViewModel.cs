using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrerTrack.Web.ViewModel
{
    public class DocumentViewModel
    {
        [Required]
        public string Title { get; set; }

        public string AltText { get; set; }

        [DataType(DataType.Html)]
        public string Caption { get; set; }

        [DataType(DataType.Upload)]
        HttpPostedFileBase ImageUpload { get; set; }
    }
}