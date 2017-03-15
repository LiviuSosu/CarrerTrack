using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.Repositories.Read
{
    public class ReadBookRepository : ReadRepositoryBase<Book>, IReadBookRepository
    {
        public IEnumerable<Book> GetUserBooks(int userId)
        {
            return db.Books.Where(book => book.UserId == userId);
        }
    }
}
