using AutoMapper;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Web.ViewModel;
using CarrerTrack.Web.ViewModel.JobAnnouncement;

namespace CarrerTrack.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<User, UserRegistrationViewModel>();
            Mapper.CreateMap<User, UserLoginViewModel>();
            Mapper.CreateMap<Model.Article, Article>();
            Mapper.CreateMap<Model.UserTask, UserTask>();
            Mapper.CreateMap<Model.Role, Role>();
            Mapper.CreateMap<Model.Company, Company>();
            Mapper.CreateMap<Model.Course,Course>();
            Mapper.CreateMap<Model.Review, Review>();
            Mapper.CreateMap<Model.Book, Book>();
            Mapper.CreateMap<Model.Location, Location>();
            Mapper.CreateMap<Model.Skill, Skill>();
            Mapper.CreateMap<Model.InterviewQuestion, InterviewQuestion>();

            Mapper.CreateMap<AddJobAnnouncement, JobAnnouncement>();
            Mapper.CreateMap<EditJobAnnouncement, JobAnnouncement>();
        }
    }
}