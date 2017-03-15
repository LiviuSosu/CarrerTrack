using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.Repositories.Read
{
    public class ReadCompanyRepository : ReadRepositoryBase<Company>, IReadCompanyRepository
    {
        public IEnumerable<Company> GetUserCompanies(int userId)
        {
            return db.Companies.Where(company=>company.UserId== userId);
        }
    }
}
