using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayboi_Infrastructure.Models
{
    public class AspNetUser: IdentityUser
    {
        [StringLength(256)]
        public string FullName { get; set; }
    }
}
