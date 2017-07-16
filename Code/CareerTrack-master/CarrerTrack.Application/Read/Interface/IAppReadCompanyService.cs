using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Read.Interface
{
    public interface IAppReadCompanyService : IAppReadServiceBase<Company>
    {
        /// <summary>
        /// Get all the Companies for the given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Company> GetUserCompanies(int userId);
    }
}
