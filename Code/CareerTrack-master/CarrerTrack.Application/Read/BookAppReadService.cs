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
    public class BookAppReadService : AppReadServiceBase<Book>, IAppReadBookService
    {
        private readonly IReadBookService _commandBookService;

        public BookAppReadService(IReadBookService commandBookService)
            :base(commandBookService)
        {
            _commandBookService = commandBookService;
        }

        public IEnumerable<Book> GetUserBooks(int userId)
        {
            return _commandBookService.GetUserBooks(userId);
        }
    }
}
