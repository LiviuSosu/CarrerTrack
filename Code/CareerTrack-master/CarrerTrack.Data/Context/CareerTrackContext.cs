using CarrerTrack.Data.EntityConfig;
using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace CarrerTrack.Data.Context
{
    public class CareerTrackContext : DbContext
    {
        public CareerTrackContext()
            : base("CarrerTrack")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<JobAnnouncement> JobAnnouncements { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<InterviewQuestion> InterviewQuestions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(1000));

            modelBuilder.Entity<JobAnnouncement>()
               .HasMany(c => c.Skills).WithMany(i => i.JobAnnouncements)
               .Map(t => t.MapLeftKey("JobAnnouncementId")
                   .MapRightKey("SkillId")
                   .ToTable("JobAddsSkills"));

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ArticleConfiguration());
            modelBuilder.Configurations.Add(new UserTaskConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new BookConfiguration());
            modelBuilder.Configurations.Add(new ReviewConfiguration());
            modelBuilder.Configurations.Add(new LocationConfiguration());
            modelBuilder.Configurations.Add(new JobAnnouncementConfiguration());
            modelBuilder.Configurations.Add(new SkillConfiguration());
            modelBuilder.Configurations.Add(new IntreviewQuestionConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateRegistered") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateRegistered").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateRegistered").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateAdded") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateAdded").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateAdded").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("IsActive") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("IsActive").CurrentValue = true;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("IsRead") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("IsRead").CurrentValue = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Status") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Status").CurrentValue = "New";
                }
            }
            return base.SaveChanges();
        }
    }
}
