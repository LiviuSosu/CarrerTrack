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
    public class ReadReviewService : ReadServiceBase<Review>, IReadReviewService
    {
        private readonly IReadReviewRepository _readRepository;

        public ReadReviewService(IReadReviewRepository readRepository)
            :base(readRepository)
        {
            _readRepository = readRepository;
        }

        public IEnumerable<Review> GetCompanyReviews(int companyId)
        {
            return _readRepository.GetCompanyReviews(companyId);
        }
    }
}
