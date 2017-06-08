using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSoulsSite.Entities.Common
{
    public class UserRole
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string RoleId { get; set; }
        public virtual IdentityRole Role { get; set; }


    }


}
