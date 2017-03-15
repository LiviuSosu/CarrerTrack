using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Read.Interface
{
    public interface IAppReadReviewService : IAppReadServiceBase<Review>
    {
        IEnumerable<Review> GetCompanyReviews(int companyId);
    }
}
