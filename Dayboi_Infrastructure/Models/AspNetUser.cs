using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayboi_Infrastructure.Models
{
    [Table("ApplicationUsers")]
    public class AspNetUser: IdentityUser
    {
        [StringLength(256)]
        public string FullName { get; set; }
    }
}
