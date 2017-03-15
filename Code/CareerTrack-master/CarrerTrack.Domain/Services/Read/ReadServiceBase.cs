using CarrerTrack.Domain.Interfaces.Read;
using CarrerTrack.Domain.Interfaces.Read.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Services.Read
{
    public class ReadServiceBase<TEntity> : IDisposable, IReadServiceBase<TEntity> where TEntity : class
    {
        private readonly IReadRepositoryBase<TEntity> _readRepository;

        public ReadServiceBase(IReadRepositoryBase<TEntity> readRepository)
        {
            _readRepository = readRepository;
        }

        public void Dispose()
        {
            _readRepository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _readRepository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _readRepository.GetById(id);
        }
    }
}
