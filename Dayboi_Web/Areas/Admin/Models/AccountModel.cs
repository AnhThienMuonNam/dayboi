using System;

namespace Dayboi_Web.Areas.Admin.Models
{
    public class AccountModel
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public DateTime? BirthDay { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        public string RoleId { get; set; }
    }
}