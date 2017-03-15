using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Domain.Interfaces.Command.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Command
{
    public class AppCommandServiceBase<TEntity> : IDisposable, IAppCommandServiceBase<TEntity> where TEntity : class
    {
        private readonly ICommandServiceBase<TEntity> _commandService;
        public AppCommandServiceBase(ICommandServiceBase<TEntity> commandService)
        {
            _commandService = commandService;
        }

        public void Add(TEntity obj)
        {
            _commandService.Add(obj);
        }

        public void Dispose()
        {
            _commandService.Dispose();
        }

        public void Remove(int objId)
        {
            _commandService.Remove(objId);
        }

        public void Update(TEntity obj)
        {
            _commandService.Update(obj);
        }
    }
}
