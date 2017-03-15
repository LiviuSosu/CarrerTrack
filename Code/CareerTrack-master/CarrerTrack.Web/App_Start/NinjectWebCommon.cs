[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CarrerTrack.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CarrerTrack.Web.App_Start.NinjectWebCommon), "Stop")]

namespace CarrerTrack.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Application.Command.Interface;
    using Application.Command;
    using Domain.Interfaces.Command.Services;
    using Domain.Services;
    using Domain.Interfaces.Command;
    using Data.Repositories.Command;
    using Application.Read;
    using Application.Read.Interface;
    using Domain.Interfaces.Read.Services;
    using Domain.Services.Read;
    using Domain.Interfaces.Read;
    using Data.Repositories.Read;
    using Domain.Services.Command;
    using Data.Context;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //read
            kernel.Bind(typeof(IAppReadServiceBase<>)).To(typeof(AppReadServiceBase<>));
            kernel.Bind<IAppReadUserService>().To<UserAppReadService>();
            kernel.Bind<IAppReadArticleService>().To<ArticleAppReadService>();
            kernel.Bind<IAppReadUserTaskService>().To<UserTaskAppReadService>();
            kernel.Bind<IAppReadRoleService>().To<RoleAppReadService>();
            kernel.Bind<IAppReadCompanyService>().To<CompanyAppReadService>();
            kernel.Bind<IAppReadCourseService>().To<CourseAppReadService>();
            kernel.Bind<IAppReadBookService>().To<BookAppReadService>();
            kernel.Bind<IAppReadReviewService>().To<ReviewAppReadService>();
            kernel.Bind<IAppReadLocationService>().To<LocationAppReadService>();
            kernel.Bind<IAppReadInterviewQuestionService>().To<InterviewQuestionAppReadService>();
            kernel.Bind<IAppReadJobAnnouncementService>().To<JobAnnouncementAppReadService>();
            kernel.Bind<IAppReadSkillService>().To<SkillAppReadService>();

            kernel.Bind(typeof(IReadServiceBase<>)).To(typeof(ReadServiceBase<>));
            kernel.Bind<IReadUserService>().To<ReadUserService>();
            kernel.Bind<IReadArticleService>().To<ReadArticleService>();
            kernel.Bind<IReadUserTaskService>().To<ReadUserTaskService>();
            kernel.Bind<IReadRoleService>().To<ReadRoleService>();
            kernel.Bind<IReadCompanyService>().To<ReadCompanyService>();
            kernel.Bind<IReadCourseService>().To<ReadCourseService>();
            kernel.Bind<IReadBookService>().To<ReadBookService>();
            kernel.Bind<IReadReviewService>().To<ReadReviewService>();
            kernel.Bind<IReadLocationService>().To<ReadLocationService>();
            kernel.Bind<IReadInterviewQuestionService>().To<ReadInterviewQuestionService>();
            kernel.Bind<IReadJobAnnouncementService>().To<ReadJobAnnouncementService>();
            kernel.Bind<IReadSkillService>().To<ReadSkillService>();

            kernel.Bind(typeof(IReadRepositoryBase<>)).To(typeof(ReadRepositoryBase<>));
            kernel.Bind<IReadUserRepository>().To<ReadUserRepository>();
            kernel.Bind<IReadArticleRepository>().To<ReadArticleRepository>();
            kernel.Bind<IReadUserTaskRepository>().To<ReadUserTaskRepository>();
            kernel.Bind<IReadRoleRepository>().To<ReadRoleRepository>();
            kernel.Bind<IReadCompanyRepository>().To<ReadCompanyRepository>();
            kernel.Bind<IReadCourseRepository>().To<ReadCourseRepository>();
            kernel.Bind<IReadBookRepository>().To<ReadBookRepository>();
            kernel.Bind<IReadReviewRepository>().To<ReadReviewRepository>();
            kernel.Bind<IReadLocationRepository>().To<ReadLocationRepository>();
            kernel.Bind<IReadInterviewQuestionRepository>().To<ReadInterviewQuestionRepository>();
            kernel.Bind<IReadJobAnnouncementRepository>().To<ReadJobAnnouncementRepository>();
            kernel.Bind<IReadSkillRepository>().To<ReadSkillRepository>();

            //command
            kernel.Bind(typeof(IAppCommandServiceBase<>)).To(typeof(AppCommandServiceBase<>));
            kernel.Bind<IAppCommandUserService>().To<UserAppCommandService>();
            kernel.Bind<IAppCommandArticleService>().To<ArticleAppCommandService>();
            kernel.Bind<IAppCommandUserTaskService>().To<UserTaskAppCommandService>();
            kernel.Bind<IAppCommandRoleService>().To<RoleAppCommandService>();
            kernel.Bind<IAppCommandCompanyService>().To<CompanyAppCommandService>();
            kernel.Bind<IAppCommandCourseService>().To<CourseAppCommandService>();
            kernel.Bind<IAppCommandBookService>().To<BookAppCommandService>();
            kernel.Bind<IAppCommandReviewService>().To<ReviewAppCommandService>();
            kernel.Bind<IAppCommandLocationService>().To<LocationAppCommandService>();
            kernel.Bind<IAppCommandInterviewQuestionService>().To<InterviewQuestionAppCommandService>();
            kernel.Bind<IAppCommandJobAnnouncementService>().To<JobAnnouncementAppCommandService>();
            kernel.Bind<IAppCommandSkillService>().To<SkillAppCommandService>();

            kernel.Bind(typeof(ICommandServiceBase<>)).To(typeof(CommandServiceBase<>));
            kernel.Bind<ICommandUserService>().To<CommandUserService>();
            kernel.Bind<ICommandArticleService>().To<CommandArticleService>();
            kernel.Bind<ICommandUserTaskService>().To<CommandUserTaskService>();
            kernel.Bind<ICommandRoleService>().To<CommandRoleService>();
            kernel.Bind<ICommandCompanyService>().To<CommandCompanyService>();
            kernel.Bind<ICommandCourseService>().To<CommandCourseService>();
            kernel.Bind<ICommandBookService>().To<CommandBookService>();
            kernel.Bind<ICommandReviewService>().To<CommandReviewService>();
            kernel.Bind<ICommandLocationService>().To<CommandLocationService>();
            kernel.Bind<ICommandInterviewQuestionService>().To<CommandInterviewQuestionService>();
            kernel.Bind<ICommandJobAnnouncementService>().To<CommandJobAnnouncementService>();
            kernel.Bind<ICommandSkillService>().To<CommandSkillService>();

            kernel.Bind(typeof(ICommandRepositoryBase<>)).To(typeof(CommandRepositoryBase<>));
            kernel.Bind<ICommandUserRepository>().To<CommandUserRepository>();
            kernel.Bind<ICommandArticleRepository>().To<CommandArticleRepository>();
            kernel.Bind<ICommandUserTaskRepository>().To<CommandUserTaskRepository>();
            kernel.Bind<ICommandRoleRepository>().To<CommandRoleRepository>();
            kernel.Bind<ICommandCompanyRepository>().To<CommandCompanyRepository>();
            kernel.Bind<ICommandCourseRepository>().To<CommandCourseRepository>();
            kernel.Bind<ICommandBookRepository>().To<CommandBookRepository>();
            kernel.Bind<ICommandReviewRepository>().To<CommandReviewRepository>();
            kernel.Bind<ICommandLocationRepository>().To<CommandLocationRepository>();
            kernel.Bind<ICommandInterviewQuestionRepository>().To<CommandInterviewQuestionRepository>();
            kernel.Bind<ICommandJobAnnouncementRepository>().To<CommandJobAnnouncementRepository>();
            kernel.Bind<ICommandSkillRepository>().To<CommandSkillRepository>();

            kernel.Bind<CareerTrackContext>().To<CareerTrackContext>().InRequestScope();
        }        
    }
}
