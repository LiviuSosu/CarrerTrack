using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read;
using CarrerTrack.Domain.Interfaces.Read.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.Repositories.Read
{
    public class ReadArticleRepository : ReadRepositoryBase<Article>, IReadArticleRepository
    {
        public IEnumerable<Article> GetUserArticles(int userId)
        {
            return db.Articles.Where(article=>article.UserId==userId) ;
        }
    }
}
