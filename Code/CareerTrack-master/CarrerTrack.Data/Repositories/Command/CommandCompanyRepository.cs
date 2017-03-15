using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Command;

namespace CarrerTrack.Data.Repositories.Command
{
    public class CommandCompanyRepository : CommandRepositoryBase<Company>, ICommandCompanyRepository
    {
    }
}
