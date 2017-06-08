using DarkSoulsSite.DbContext;
using DarkSoulsSite.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DarkSoulsSiteMVC.Controllers
{
    [Authorize]
    public class UsersRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        // GET: UsersRoles
        public ActionResult Index()
        {
            
            return View(db.Roles.ToList());
        }

        public async Task<ActionResult> GetRolesForUser(string userId)
        {
            using (
                var userManager =
                    new UserManager<User>(new UserStore<User>(new ApplicationDbContext())))
            {
                var rolesForUser = await userManager.GetRolesAsync(userId);

                return this.View(rolesForUser);
            }
        }
    }
}