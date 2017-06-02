using DarkSoulsSite.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkSoulsSite.Entities.Common;
using DarkSoulsSite.Entities.Items;
using DarkSoulsSite.DbContext.Migrations;

namespace DarkSoulsSite.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public virtual IDbSet<Character> Characters { get; set; }
        //public virtual IDbSet<Item> Items { get; set; }
        public virtual IDbSet<Weapon> Weapons { get; set; }
        public virtual IDbSet<Armor> Armors { get; set; }
        public virtual IDbSet<Magic> Magics { get; set; }
        public virtual IDbSet<Boss> Bossеs { get; set; }

        public ApplicationDbContext()
            //: base("DarkSoulsSiteConnection", throwIfV1Schema: false)
            : base("DarkSoulsSite-DevConnection", throwIfV1Schema: false)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}