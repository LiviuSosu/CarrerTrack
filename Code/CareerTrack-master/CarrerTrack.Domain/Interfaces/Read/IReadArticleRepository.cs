using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Interfaces.Read
{
    public interface IReadArticleRepository : IReadRepositoryBase<Article>
    {
        IEnumerable<Article> GetUserArticles(int userId);
    }
}
