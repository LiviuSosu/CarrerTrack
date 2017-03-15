using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Interfaces.Command
{
    public interface ICommandCompanyRepository : ICommandRepositoryBase<Company>
    {
    }
}
