using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Read
{
    public class ArticleAppReadService : AppReadServiceBase<Article>, IAppReadArticleService
    {
        private readonly IReadArticleService _commandArticleService;

        public ArticleAppReadService(IReadArticleService commandArticleService)
            :base(commandArticleService)
        {
            _commandArticleService = commandArticleService;
        }

        public IEnumerable<Article> GetUserArticles(int userId)
        {
            return _commandArticleService.GetUserArticles(userId);
        }
    }
}
