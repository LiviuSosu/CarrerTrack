using CarrerTrack.Data.Context;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.Repositories.Read
{
    public class ReadRepositoryBase<TEntity> : IDisposable, IReadRepositoryBase<TEntity> where TEntity : class
    {
        protected CareerTrackContext db = new CareerTrackContext();

        public TEntity GetById(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>();
        }
    }
}
