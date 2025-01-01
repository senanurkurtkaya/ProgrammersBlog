using Microsoft.AspNetCore.Identity;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string UserName { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public string Picture { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }

        public string About { get; set; }
        public string YoutubeLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string LinkedInLink { get; set; }
        public string GitHubLink { get; set; }
        public string WebsiteLink { get; set; }

        public ICollection<Article> Articles { get; set; }

       



    }
}
