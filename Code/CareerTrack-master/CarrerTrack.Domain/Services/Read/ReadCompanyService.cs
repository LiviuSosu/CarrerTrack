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
    public class ReadCompanyService : ReadServiceBase<Company>, IReadCompanyService
    {
        private readonly IReadCompanyRepository _readRepository;

        public ReadCompanyService(IReadCompanyRepository readRepository)
            : base(readRepository)
        {
            _readRepository = readRepository;
        }

        public IEnumerable<Company> GetUserCompanies(int userId)
        {
            return _readRepository.GetUserCompanies(userId);
        }
    }
}
