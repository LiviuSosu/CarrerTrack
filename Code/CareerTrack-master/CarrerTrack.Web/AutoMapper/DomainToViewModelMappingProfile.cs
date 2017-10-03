using AutoMapper;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Web.ViewModel;
using CarrerTrack.Web.ViewModel.JobAnnouncement;

namespace CarrerTrack.Web.AutoMapper
{
    /// <summary>
    /// documentation: https://github.com/AutoMapper/AutoMapper/wiki/Configuration
    /// </summary>
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<UserRegistrationViewModel, User>();
            CreateMap<UserLoginViewModel, User>();
            CreateMap<Article, Model.Article>();
            CreateMap<UserTask, Model.UserTask>();
            CreateMap<Role, Model.Role>();
            CreateMap<Company, Model.Company>();
            CreateMap<Course, Model.Course>();
            CreateMap<Book, Model.Book>();
            CreateMap<Review, Model.Review>();
            CreateMap<Location, Model.Location>();
            CreateMap<InterviewQuestion, Model.InterviewQuestion>();
            CreateMap<Skill, Model.Skill>();
            CreateMap<JobAnnouncement, Model.JobAnnouncement>();
            CreateMap<JobAnnouncement, AddJobAnnouncementViewModel>();
            CreateMap<User, Model.User>();
        }
    }
}