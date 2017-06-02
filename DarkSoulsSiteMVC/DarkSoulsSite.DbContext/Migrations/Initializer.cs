using DarkSoulsSite.Common.Extensions;
using DarkSoulsSite.Entities;
using DarkSoulsSite.Entities.Items;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        internal static void SeedItems(ApplicationDbContext context)
        {
            var ar = new Armor
            {
                Name = "ar",
                Level = 15,
                BaseArmor = 60,
                FireDefense = 50,
                IceDefense = 40,
                LightningDefense = 30,
                Image = "https://" +
               "vignette1.wikia.nocookie.net/warframe/images/0/03/" +
               "LatoPrimePistolHI.png/revision/latest?cb=20130406033121",
                Id = new CustomId().ToString()
            };

            var mag = new Magic
            {
                Name = "mag",
                Level = 15,
                BaseMagic = 60,
                Fire = 50,
                Ice = 40,
                Lightning = 30,
                Image = "https://" +
               "vignette1.wikia.nocookie.net/warframe/images/0/03/" +
               "LatoPrimePistolHI.png/revision/latest?cb=20130406033121",
                Id = new CustomId().ToString()
            };

            var weap = new Weapon
            {
                Name = "weap",
                Level = 15,
                BaseDamage = 60,
                Bleed = true,
                Poison = false,
                Image = "https://" +
                "vignette1.wikia.nocookie.net/warframe/images/0/03/" +
                "LatoPrimePistolHI.png/revision/latest?cb=20130406033121",
                Id = new CustomId().ToString()
            };

            context.Armors.Add(ar);
            context.Magics.Add(mag);
            context.Weapons.Add(weap);

            SaveChanges(context);
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

            //var us = new User
            //{
            //    UserName = "q",
            //    PasswordHash = hasher.HashPassword("1"),
            //    Email = "q@abv.bg",
            //    EmailConfirmed = true,
            //    SecurityStamp = new CustomId().ToString()
            //};

            ad.Roles.Add(new IdentityUserRole { RoleId = userRoleAdmin.Id, UserId = ad.Id });
            context.Users.Add(ad);
        }
        //internal static void SeedCharacters(ApplicationDbContext context)
        //{
        //    throw new NotImplementedException();
        //}

        private static void SaveChanges(ApplicationDbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }
        }
    }
}
