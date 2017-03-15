using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.Repositories.Command
{
    public class CommandArticleRepository : CommandRepositoryBase<Article>, ICommandArticleRepository
    {
    }
}
