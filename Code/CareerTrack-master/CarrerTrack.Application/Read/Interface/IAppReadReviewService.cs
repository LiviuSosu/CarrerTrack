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
        /// <summary>
        /// Get all CompanyReviews for a given company id
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IEnumerable<Review> GetCompanyReviews(int companyId);
    }
}
