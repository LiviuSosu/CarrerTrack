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
    public class CourseAppReadService : AppReadServiceBase<Course>, IAppReadCourseService
    {
        private readonly IReadCourseService _commandCourseService;

        public CourseAppReadService(IReadCourseService commandCourseService)
            : base(commandCourseService)
        {
            _commandCourseService = commandCourseService;
        }

        IEnumerable<Course> IAppReadCourseService.GetUserCourse(int userId)
        {
            return _commandCourseService.GetUserCourse(userId);
        }
    }
}
