using CarrerTrack.Data.Context;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using CarrerTrack.Domain.Entities;

namespace CareerTrack.Utils.Functionalities.MockCompaniesNames
{
    class CompanyNameMocker
    {
        CareerTrackContext db = new CareerTrackContext();
        List<string> companyNames = new List<string>();
        string path = @"C:\Users\liviu.sosu\Work\Projects\Career Track\Career Track\Career-Track\Code\CareerTrack-master\CareerTrack.Utils\Functionalities\MockCompaniesNames\CompanyNames.json";

        public void WriteCompaniesNamesToFile(List<string> companyNames)
        {
            string json = JsonConvert.SerializeObject(companyNames);
            File.WriteAllText(path, json);
        }

        public List<string> GetCompanyNames()
        {
            foreach (var company in db.Companies)
            {
                companyNames.Add(company.CompanyName);
            }

            return companyNames;
        }

        public int GetNumberOfCompanies()
        {
            return db.Companies.Count();
        }

        public void MockCompanyNames()
        {
            int count = 1;
            foreach(var company in db.Companies)
            {
                company.CompanyName = "Company name " + count;
                db.Entry<Company>(company).CurrentValues.SetValues(company);
                count++;
            }

            db.SaveChanges();
        }

        public void RenameCompanies()
        {
            string json = File.ReadAllText(path);
            List<string> companyNames = JsonConvert.DeserializeObject<List<string>>(json);
            int index = 0;

            foreach (var company in db.Companies)
            {
                company.CompanyName = companyNames[index];
                db.Entry<Company>(company).CurrentValues.SetValues(company);
                index++;
            }

            db.SaveChanges();
        }
    }
}
