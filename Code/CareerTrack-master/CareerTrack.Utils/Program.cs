using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarrerTrack.Data;
using CarrerTrack.Data.Context;
using CareerTrack.Utils.Functionalities.BrokenLink;
using CareerTrack.Logging;
using System.Timers;
using CareerTrack.Utils.Functionalities.SimilarStrings;
using CareerTrack.Utils.Functionalities.MockCompaniesNames;

namespace CareerTrack.Utils
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyNameMocker companyMoker = new CompanyNameMocker();
            //List<string> companyNames = new List<string>();
            //companyNames = companyMoker.GetCompanyNames();
            //companyMoker.WriteCompaniesNamesToFile(companyNames);

            companyMoker.RenameCompanies();

            //Task.Factory.StartNew(() =>
            //{
            //    CareerTrackContext db = new CareerTrackContext();
            //    IBrokenLink brokenLink = new BrokenLink();
            //    System.Threading.Thread.Sleep(60 * 60 * 1000 * 24);
            //    brokenLink.SetBrokenLinks(db.Articles);
            //});
        }
    }
}
