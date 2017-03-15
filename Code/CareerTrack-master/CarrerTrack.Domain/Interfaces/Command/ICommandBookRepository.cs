using CarrerTrack.Domain.Entities;

namespace CarrerTrack.Domain.Interfaces.Command
{
    public interface ICommandBookRepository : ICommandRepositoryBase<Book>
    {
        void RemoveBookAttachement(int bookId);
    }
}
