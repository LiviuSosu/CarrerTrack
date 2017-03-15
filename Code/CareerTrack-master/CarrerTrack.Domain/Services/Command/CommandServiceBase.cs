using CarrerTrack.Domain.Interfaces.Command;
using CarrerTrack.Domain.Interfaces.Command.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Services
{
    public class CommandServiceBase<TEntity> : IDisposable, ICommandServiceBase<TEntity> where TEntity : class
    {
        private readonly ICommandRepositoryBase<TEntity> _commandRepository;

        public CommandServiceBase(ICommandRepositoryBase<TEntity> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public void Add(TEntity obj)
        {
            _commandRepository.Add(obj);
        }

        public void Dispose()
        {
            _commandRepository.Dispose();
        }

        public void Remove(int objId)
        {
            _commandRepository.Remove(objId);
        }

        public void Update(TEntity obj)
        {
            _commandRepository.Update(obj);
        }
    }
}
