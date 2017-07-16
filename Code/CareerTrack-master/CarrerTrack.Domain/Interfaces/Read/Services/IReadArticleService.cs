using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Interfaces.Read.Services
{
    public interface IReadArticleService : IReadServiceBase<Article>
    {
        /// <summary>
        /// Returns all the Articles for a given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Article> GetUserArticles(int userId);
    }
}
