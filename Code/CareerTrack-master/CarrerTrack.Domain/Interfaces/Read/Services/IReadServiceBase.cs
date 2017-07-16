using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Interfaces.Read.Services
{
    /// <summary>
    /// Following the CQRS pattern, only methods that requires query will be on this side and not those which will modify the data
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IReadServiceBase<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Dispose();
    }
}
