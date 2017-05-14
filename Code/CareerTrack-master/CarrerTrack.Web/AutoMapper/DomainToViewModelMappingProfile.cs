using AutoMapper;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Web.ViewModel;
using CarrerTrack.Web.ViewModel.JobAnnouncement;

namespace CarrerTrack.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMapping";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UserRegistrationViewModel, User>();
            Mapper.CreateMap<UserLoginViewModel, User>();
            Mapper.CreateMap<Article,Model.Article>();
            Mapper.CreateMap<UserTask, Model.UserTask>();
            Mapper.CreateMap<Role, Model.Role>();
            Mapper.CreateMap<Company, Model.Company>();
            Mapper.CreateMap<Course, Model.Course>();
            Mapper.CreateMap<Book, Model.Book>();
            Mapper.CreateMap<Review, Model.Review>();
            Mapper.CreateMap<Location, Model.Location>();
            Mapper.CreateMap<InterviewQuestion, Model.InterviewQuestion>();
            Mapper.CreateMap<Skill, Model.Skill>();
            Mapper.CreateMap<JobAnnouncement, Model.JobAnnouncement>();
            Mapper.CreateMap<JobAnnouncement, AddJobAnnouncementViewModel>();

            Mapper.CreateMap<Domain.Entities.User, Model.User>();
        }
    }
}