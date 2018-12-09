using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dayboi_Infrastructure.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(256)]
        public string FullName { set; get; }

        [StringLength(256)]
        public string Address { set; get; }

        public DateTime? BirthDay { set; get; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public ICollection<EnrollmentCourse> EnrollmentCourses { get; set; }
    }
}
