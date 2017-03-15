using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read;
using CarrerTrack.Domain.Interfaces.Read.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Services.Read
{
    public class ReadArticleService : ReadServiceBase<Article>, IReadArticleService
    {
        private readonly IReadArticleRepository _readRepository;

        public ReadArticleService(IReadArticleRepository readRepository)
            :base(readRepository)
        {
            _readRepository = readRepository;
        }

        public IEnumerable<Article> GetUserArticles(int userId)
        {
           return _readRepository.GetUserArticles(userId);
        }
    }
}
