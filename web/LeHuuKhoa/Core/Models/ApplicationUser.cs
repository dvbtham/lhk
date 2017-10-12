using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeHuuKhoa.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public DateTime Birthday { get; set; }

        public string Gender { get; set; }

        public void Modify(string name, string email, string image, DateTime birthday, string gender)
        {
            Email = email;
            Name = name;
            ImageUrl = image;
            Birthday = birthday;
            Gender = gender;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}