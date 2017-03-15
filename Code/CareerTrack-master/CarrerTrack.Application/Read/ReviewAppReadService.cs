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
    public class ReviewAppReadService : AppReadServiceBase<Review>, IAppReadReviewService
    {
        private readonly IReadReviewService _commandReviewService;

        public ReviewAppReadService(IReadReviewService commandReviewService)
            : base(commandReviewService)
        {
            _commandReviewService = commandReviewService;
        }

        public IEnumerable<Review> GetCompanyReviews(int companyId)
        {
            return _commandReviewService.GetCompanyReviews(companyId);
        }
    }
}
