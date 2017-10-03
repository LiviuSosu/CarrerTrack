using AutoMapper;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Web.ViewModel;
using CarrerTrack.Web.ViewModel.JobAnnouncement;

namespace CarrerTrack.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<User, UserRegistrationViewModel>();
            CreateMap<User, UserLoginViewModel>();
            CreateMap<Model.Article, Article>();
            CreateMap<Model.UserTask, UserTask>();
            CreateMap<Model.Role, Role>();
            CreateMap<Model.Company, Company>();
            CreateMap<Model.Course, Course>();
            CreateMap<Model.Review, Review>();
            CreateMap<Model.Book, Book>();
            CreateMap<Model.Location, Location>();
            CreateMap<Model.Skill, Skill>();
            CreateMap<Model.InterviewQuestion, InterviewQuestion>();
            CreateMap<AddJobAnnouncementViewModel, JobAnnouncement>();
            CreateMap<EditJobAnnouncementViewModel, JobAnnouncement>();
            CreateMap<Model.User, User>();
        }
    }
}