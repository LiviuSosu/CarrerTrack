using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarrerTrack.Web.ViewModel.JobAnnouncement
{
    public class DetailsJobAnnouncement : Model.JobAnnouncement
    {
        public string RoleName { get; set; }
        public string LocationName { get; set; }
        public string CompanyName { get; set; }      
    }
}