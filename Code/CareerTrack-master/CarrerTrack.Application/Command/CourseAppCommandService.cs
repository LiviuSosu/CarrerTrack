using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Command.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Command
{
    public class CourseAppCommandService : AppCommandServiceBase<Course>, IAppCommandCourseService
    {
        private readonly ICommandCourseService _commandCourseService;

        public CourseAppCommandService(ICommandCourseService commandCourseService)
            :base(commandCourseService)
        {
            _commandCourseService = commandCourseService;
        }
    }
}
