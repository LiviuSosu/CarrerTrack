﻿using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read;
using CarrerTrack.Domain.Interfaces.Read.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Services.Read
{
    public class ReadBookService : ReadServiceBase<Book>, IReadBookService
    {
        private readonly IReadBookRepository _readRepository;

        public ReadBookService(IReadBookRepository readRepository)
            :base(readRepository)
        {
            _readRepository = readRepository;
        }

        public IEnumerable<Book> GetUserBooks(int userId)
        {
            return _readRepository.GetUserBooks(userId);
        }
    }
}
