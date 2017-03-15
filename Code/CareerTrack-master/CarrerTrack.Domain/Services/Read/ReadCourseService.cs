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
    public class ReadCourseService : ReadServiceBase<Course>, IReadCourseService
    {
        private readonly IReadCourseRepository _readRepository;

        public ReadCourseService(IReadCourseRepository readRepository)
            :base(readRepository)
        {
            _readRepository = readRepository;
        }

        IEnumerable<Course> IReadCourseService.GetUserCourse(int userId)
        {
            return _readRepository.GetUserCourse(userId);
        }
    }
}
