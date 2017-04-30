using CareerTrack.Logging;
using CarrerTrack.Data.Context;
using CarrerTrack.Domain.Entities;
using System.Collections.Generic;
using System.Net;

namespace CareerTrack.Utils.Functionalities.BrokenLink
{
    internal class BrokenLink : IBrokenLink
    {
        CareerTrackContext db = new CareerTrackContext();

        public void SetBrokenLinks(IEnumerable<Article> articles)
        {
            foreach (var article in articles)
            {
                if(!IsLinkValid(article.Link))
                {
                    Article _article = db.Articles.Find(article.ArticleId);
                    _article.BrokenLink = true;
                    db.Entry(_article).CurrentValues.SetValues(_article);
                    db.SaveChanges();

                    ILogging logger = new Logging.Logging();
                    logger.LogBrokenLink(article.Link);
                }
            }
        }

        private bool IsLinkValid(string link)
        {
            bool isValid = true;

            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(link) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                isValid = (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                isValid = false;
            }

            return isValid;
        }
    }
}
