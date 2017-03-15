using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.Repositories.Read
{
    public class ReadCourseRepository : ReadRepositoryBase<Course>, IReadCourseRepository
    {
        public IEnumerable<Course> GetUserCourse(int userId)
        {
            return db.Courses.Where(r => r.UserId == userId);
        }
    }
}
