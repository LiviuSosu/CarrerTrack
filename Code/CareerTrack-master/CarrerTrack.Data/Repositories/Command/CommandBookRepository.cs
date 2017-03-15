using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.Repositories.Command
{
    public class CommandBookRepository : CommandRepositoryBase<Book>, ICommandBookRepository
    {
        public void RemoveBookAttachement(int bookId)
        {
            var book = db.Books.Find(bookId);
            book.Content = null;
            book.ContentType = null;
            db.Entry<Book>(book).CurrentValues.SetValues(book);
            db.SaveChanges();
        }
    }
}
