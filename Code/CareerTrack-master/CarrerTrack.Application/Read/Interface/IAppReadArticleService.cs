using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Read.Interface
{
    public interface IAppReadArticleService : IAppReadServiceBase<Article>
    {
        /// <summary>
        /// Returns all the Articles for a given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Article> GetUserArticles(int userId);
    }
}
