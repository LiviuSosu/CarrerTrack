using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Command;
using CarrerTrack.Domain.Interfaces.Command.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Services.Command
{
    public class CommandBookService : CommandServiceBase<Book>, ICommandBookService
    {
        private readonly ICommandBookRepository _commandRepository;

        public CommandBookService(ICommandBookRepository commandRepository)
            :base(commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public void RemoveBookAttachement(int bookId)
        {
            _commandRepository.RemoveBookAttachement(bookId);
        }
    }
}
