using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read;
using CarrerTrack.Domain.Interfaces.Read.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Services.Read
{
    public class ReadRoleService : ReadServiceBase<Role>, IReadRoleService
    {
        private readonly IReadRoleRepository _readRepository;

        public ReadRoleService(IReadRoleRepository readRepository)
            :base(readRepository)
        {
            _readRepository = readRepository;
        }

        public IEnumerable<Role> GetUserRoles(int userId)
        {
            return _readRepository.GetUserRoles(userId);
        }
    }
}
