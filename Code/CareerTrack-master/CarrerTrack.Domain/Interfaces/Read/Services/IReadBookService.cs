using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Interfaces.Read.Services
{
    public interface IReadBookService : IReadServiceBase<Book>
    {
        /// <summary>
        /// Returns all the Books for a given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Book> GetUserBooks(int userId);
    }
}
