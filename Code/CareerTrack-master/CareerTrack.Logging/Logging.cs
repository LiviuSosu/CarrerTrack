using System.IO;
using System;

namespace CareerTrack.Logging
{
    public class Logging : ILogging
    {
        string path = @"C:\\Users\\liviu.sosu\\Work\\Projects\\Career Track\\Career Track\\Career-Track\\Code\\CareerTrack-master\\CareerTrack.Logging\\LoggingFiles\\";// System.Configuration.ConfigurationManager.AppSettings["LoggingFilesPath"];
       
        public void LogBrokenLink(string link)
        {
            string brokenLinksLogFilePath = path + @"BrokenLinks\BrokenLinks.txt";

            using (StreamWriter sw = File.AppendText(brokenLinksLogFilePath))
            {
                sw.WriteLine("This link " + link + " was found as broken on "+ DateTime.Today.ToShortDateString());
                sw.Close();
            }
        }
        
        public void LogCompanyExceptionOnJobAdd(int companyID, string companyName, int userID)
        {
            string brokenLinksLogFilePath = path + @"Companies\Companies.txt";

            using (StreamWriter sw = File.AppendText(brokenLinksLogFilePath))
            {
                sw.WriteLine("The user having the id: "+ userID+" attempted to insert the company with ID " +companyID +" ("+ companyName + ") on " + DateTime.Today.ToShortDateString());
                sw.Close();
            }
        }

        public void LogSimilarCompany(int companyID, string companyName, int userID)
        {
            string brokenLinksLogFilePath = path + @"Companies\Companies.txt";

            using (StreamWriter sw = File.AppendText(brokenLinksLogFilePath))
            {
                sw.WriteLine("The user having the id: " + userID + " attempted to insert the company with ID " + companyID + " (" + companyName + ") on " + DateTime.Today.ToShortDateString());
                sw.Close();
            }
        }

        public void LogSimilarArticle(int skillID, string skillName, int userID)
        {
            string brokenLinksLogFilePath = path + @"Articles\Articles.txt";

            using (StreamWriter sw = File.AppendText(brokenLinksLogFilePath))
            {
                sw.WriteLine("The user having the id: " + userID + " attempted to insert the skill with ID " + skillID + " (" + skillName + ") on " + DateTime.Today.ToShortDateString());
                sw.Close();
            }
        }

        public void LogSimilarSkill(int skillID, string skillName, int userID)
        {
            string brokenLinksLogFilePath = path + @"Skills\Skills.txt";

            using (StreamWriter sw = File.AppendText(brokenLinksLogFilePath))
            {
                sw.WriteLine("The user having the id: " + userID + " attempted to insert the skill with ID " + skillID + " (" + skillName + ") on " + DateTime.Today.ToShortDateString());
                sw.Close();
            }
        }

        public void LogDeactivatedUsersAttemptsToChangePassword(int userId)
        {
            string usersLogFilePath = path + @"Users\Users.txt";

            using (StreamWriter sw = File.AppendText(usersLogFilePath))
            {
                sw.WriteLine("The user having the id: " + userId + " attempted to change the passwor on " + DateTime.Today.ToShortDateString());
                sw.Close();
            }
        }
    }
}
