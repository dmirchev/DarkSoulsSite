using DarkSoulsSite.Common.Extensions;
using DarkSoulsSite.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSoulsSite.DbContext.Migrations
{
    internal class Initializer
    {
        internal static void SeedRoles(ApplicationDbContext context)
        {
            string[] roles =
            {
                "Administrator",
                "Editor",
                "Boss",
                "Player",
                "Guest"
            };

            foreach (var role in roles)
            {
                var roleStore = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!context.Roles.Any(r => r.Name == role))
                {
                    roleStore.Create(new IdentityRole(role));
                }
            }
        }
        internal static void SeedUser(ApplicationDbContext context)
        {
            string admin = "admin";
            var userRoleAdmin = new IdentityRole { Id = new CustomId().ToString(), Name = admin };
            context.Roles.Add(userRoleAdmin);

            var hasher = new PasswordHasher();

            var ad = new User
            {
                UserName = admin,
                PasswordHash = hasher.HashPassword("admin"),
                Email = "admin@abv.bg",
                EmailConfirmed = true,
                SecurityStamp = new CustomId().ToString()
            };

            ad.Roles.Add(new IdentityUserRole { RoleId = userRoleAdmin.Id, UserId = ad.Id });
            context.Users.Add(ad);
        }
        //internal static void SeedCharacters(ApplicationDbContext context)
        //{
        //    throw new NotImplementedException();
        //}

        
    }
}
