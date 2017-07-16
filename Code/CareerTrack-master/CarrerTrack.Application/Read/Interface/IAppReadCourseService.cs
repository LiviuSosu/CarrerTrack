using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Read.Interface
{
    public interface IAppReadCourseService : IAppReadServiceBase<Course>
    {
        /// <summary>
        /// Returns all the courses for a given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Course> GetUserCourse(int userId);
    }
}
