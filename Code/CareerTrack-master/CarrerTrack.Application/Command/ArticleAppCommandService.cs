using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Command.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Command
{
    public class ArticleAppCommandService : AppCommandServiceBase<Article>, IAppCommandArticleService
    {
        private readonly ICommandArticleService _commandArticleService;

        public ArticleAppCommandService(ICommandArticleService commandArticleService)
            :base(commandArticleService)
        {
            _commandArticleService = commandArticleService;
        }
    }
}
