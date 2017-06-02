namespace DarkSoulsSite.DbContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Roles.Any())
            {
                Initializer.SeedRoles(context);
            }

            if (!context.Users.Any())
            {
                Initializer.SeedUser(context);
            }

            Initializer.SeedItems(context);

            //if (!context.Users.Any())
            //{
            //    Initializer.SeedWeapon(context);
            //}

            //if (!context.Users.Any())
            //{
            //    Initializer.SeedArmor(context);
            //}

            //if (!context.Users.Any())
            //{
            //    Initializer.SeedMagic(context);
            //}



            //Initializer.SeedCharacters(context);

            //Initializer.SeedBosses(context);
        }
    }
}
