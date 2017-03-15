using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Command.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CarrerTrack.Application.Command
{
    public class BookAppCommandService : AppCommandServiceBase<Book>, IAppCommandBookService
    {
        private readonly ICommandBookService _commandBookService;

        public BookAppCommandService(ICommandBookService commandBookService)
            :base(commandBookService)
        {
            _commandBookService = commandBookService;
        }

        public void RemoveBookAttachement(int bookId)
        {
            _commandBookService.RemoveBookAttachement(bookId);
        }
    }
}