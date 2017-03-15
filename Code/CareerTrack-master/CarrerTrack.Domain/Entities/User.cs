using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Entities
{
    public class User
    {
        public User()
        {
            this.UserTasks = new HashSet<UserTask>();
            this.Articles = new HashSet<Article>();
            this.Roles = new HashSet<Role>();
            this.Companies = new HashSet<Company>();
            this.Reviews = new HashSet<Review>();
            this.Locations = new HashSet<Location>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime DateRegistered { get; set; }
        public bool IsActive { get; set; }

        public virtual IEnumerable<Article> Articles { get; set; }
        public virtual IEnumerable<UserTask> UserTasks { get; set; }
        public virtual IEnumerable<Role> Roles { get; set; }
        public virtual IEnumerable<Company> Companies { get; set; }
        public virtual IEnumerable<Review> Reviews { get; set; }
        public virtual IEnumerable<Location> Locations { get; set; }
    }
}
