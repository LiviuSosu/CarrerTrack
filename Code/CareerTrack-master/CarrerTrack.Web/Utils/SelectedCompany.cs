using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarrerTrack.Web.Utils
{
    public static class SelectedCompany
    {
        private static int seletectedCompanyId;
        public static int SelectedCompanyId
        {
            get
            {
                return seletectedCompanyId;
            }
            set
            {
                seletectedCompanyId = value;
            }
        }
    }
}