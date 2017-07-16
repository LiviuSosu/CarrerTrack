using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Command.Interface
{
    public interface IAppCommandBookService : IAppCommandServiceBase<Book>
    {
        /// <summary>
        /// This method requers deleteing a BLOB from database, therefore the implementation of the DELETE method is slightly different
        /// </summary>
        /// <param name="bookId"></param>
        void RemoveBookAttachement(int bookId);
    }
}
