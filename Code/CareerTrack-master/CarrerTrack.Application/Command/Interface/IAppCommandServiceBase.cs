using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Command.Interface
{
    /// <summary>
    /// Following the CQRS pattern, on the command sie we have methods that only modifies the data and no reading query actions are performed.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IAppCommandServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(int objId);
        void Dispose();
    }
}
