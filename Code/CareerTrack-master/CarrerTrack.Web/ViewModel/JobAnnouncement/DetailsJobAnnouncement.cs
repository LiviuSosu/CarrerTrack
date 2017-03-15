using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarrerTrack.Web.ViewModel.JobAnnouncement
{
    public class DetailsJobAnnouncement : Model.JobAnnouncement
    {
        //public string Content { get; set; }

        //public string Rewards { get; set; }

        //public string Source { get; set; }

        //public string Contact { get; set; }

        public string RoleName { get; set; }
        public string LocationName { get; set; }
        public string CompanyName { get; set; }
         
    }
}