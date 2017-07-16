using CarrerTrack.Domain.Entities;

namespace CarrerTrack.Domain.Interfaces.Command
{
    public interface ICommandBookRepository : ICommandRepositoryBase<Book>
    {
        /// <summary>
        /// This method requers deleteing a BLOB from database, therefore the implementation of the DELETE method is slightly different
        /// </summary>
        /// <param name="bookId"></param>
        void RemoveBookAttachement(int bookId);
    }
}
