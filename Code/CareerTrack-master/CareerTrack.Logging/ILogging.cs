namespace CareerTrack.Logging
{
    public interface ILogging
    {
        void LogBrokenLink(string link);
        void LogCompanyExceptionOnJobAdd(int companyID, string companyName, int userID);
        void LogSimilarCompany(int companyID, string companyName, int userID);
        void LogSimilarArticle(int skillID, string skillName, int userID);
        void LogSimilarSkill(int skillID, string skillName, int userID);
        void LogDeactivatedUsersAttemptsToChangePassword(int userId);
    }
}
