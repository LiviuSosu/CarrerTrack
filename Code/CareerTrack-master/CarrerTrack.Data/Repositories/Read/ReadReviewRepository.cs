using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.Repositories.Read
{
    public class ReadReviewRepository : ReadRepositoryBase<Review>, IReadReviewRepository
    {
        public IEnumerable<Review> GetCompanyReviews(int companyId)
        {
            return db.Reviews.Where(review=>review.CompanyId == companyId);
        }
    }
}
