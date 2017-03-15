using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Interfaces.Read.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Read
{
    public class AppReadServiceBase<TEntity> : IDisposable, IAppReadServiceBase<TEntity> where TEntity : class
    {
        private readonly IReadServiceBase<TEntity> _readService;
        public AppReadServiceBase(IReadServiceBase<TEntity> readService)
        {
            _readService = readService;
        }

        public void Dispose()
        {
            _readService.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _readService.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _readService.GetById(id);
        }
    }
}
