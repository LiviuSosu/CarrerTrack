using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Read
{
    public class CompanyAppReadService : AppReadServiceBase<Company>, IAppReadCompanyService
    {
        private readonly IReadCompanyService _commandCompanyService;

        public CompanyAppReadService(IReadCompanyService commandCompanyService)
            : base(commandCompanyService)
        {
            _commandCompanyService = commandCompanyService;
        }

        IEnumerable<Company> IAppReadCompanyService.GetUserCompanies(int userId)
        {
            return _commandCompanyService.GetUserCompanies(userId);
        }
    }
}
