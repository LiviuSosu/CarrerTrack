namespace CareerTrack.Logging
{
    public interface ILogging
    {
    /// <summary>
    /// Writes on the file BrokenLinks.txt if a specific link is no longer valid (it points to a inexisting page)
    /// </summary>
    /// <param name="link"> this is the link specified </param>
        void LogBrokenLink(string link);
        /// <summary>
        /// Writes on the file Companies.txt if the company does not exist when adding a new job announcement.
        /// The user id will be logged as well in case it will be need to indentify him/her for a given reason.
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="companyName"></param>
        /// <param name="userID"></param>
        void LogCompanyExceptionOnJobAdd(int companyID, string companyName, int userID);
        /// <summary>
        /// Writes on the file Companies.txt if the company already exists.
        /// The user id will be logged as well in case it will be need to indentify him/her for a given reason.
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="companyName"></param>
        /// <param name="userID"></param>
        void LogSimilarCompany(int companyID, string companyName, int userID);
        /// <summary>
        /// Writes on the file Articles.txt if two articles have similar title. The algorithm for determining if a given string is similar is defined in CareerTrack.Utils.Functionalities.SimilarStrings
        /// </summary>
        /// <param name="skillID"></param>
        /// <param name="skillName"></param>
        /// <param name="userID"></param>
        void LogSimilarArticle(int skillID, string skillName, int userID);
        /// <summary>
        /// Writes on the file Skills.txt if two skills have similar names. The algorithm for determining if a given string is similar is defined in CareerTrack.Utils.Functionalities.SimilarStrings
        /// </summary>
        /// <param name="skillID"></param>
        /// <param name="skillName"></param>
        /// <param name="userID"></param>
        void LogSimilarSkill(int skillID, string skillName, int userID);

        /// <summary>
        /// Writes on the file Users.txt if a user was deactivated after three unsuccesfull login attempts.
        /// </summary>
        /// <param name="userId"></param>
        void LogDeactivatedUsersAttemptsToChangePassword(int userId);
    }
}
