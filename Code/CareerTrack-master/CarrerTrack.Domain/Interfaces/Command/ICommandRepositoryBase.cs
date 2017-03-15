
namespace CarrerTrack.Domain.Interfaces.Command
{
    public interface ICommandRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(int objId);
        void Dispose();
    }
}
