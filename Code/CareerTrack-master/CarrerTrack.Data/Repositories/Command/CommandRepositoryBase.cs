using CarrerTrack.Data.Context;
using CarrerTrack.Domain.Interfaces.Command;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.Repositories.Command
{
    public class CommandRepositoryBase<TEntity> : IDisposable, ICommandRepositoryBase<TEntity> where TEntity : class
    {
        protected CareerTrackContext db = new CareerTrackContext();

        public void Add(TEntity obj)
        {
            db.Set<TEntity>().Add(obj);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Remove(int objId)
        {
            TEntity obj = db.Set<TEntity>().Find(objId);
            db.Set<TEntity>().Remove(obj);
            db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
