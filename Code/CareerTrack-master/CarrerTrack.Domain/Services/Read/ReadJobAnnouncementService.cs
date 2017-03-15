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
    public class ReadJobAnnouncementService : ReadServiceBase<JobAnnouncement>, IReadJobAnnouncementService
    {
        private readonly IReadJobAnnouncementRepository _readRepository;

        public ReadJobAnnouncementService(IReadJobAnnouncementRepository readRepository)
            :base(readRepository)
        {
            _readRepository = readRepository;
        }
    }
}
