using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Interfaces.Read
{
    public interface IReadReviewRepository : IReadRepositoryBase<Review>
    {
        IEnumerable<Review> GetCompanyReviews(int companyId);
    }
}
