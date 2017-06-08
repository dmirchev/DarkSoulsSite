namespace DarkSoulsSite.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalStats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "FinalDamage", c => c.Int(nullable: false));
            AddColumn("dbo.Characters", "FinalArmor", c => c.Int(nullable: false));
            AddColumn("dbo.Characters", "FinalMagic", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "FinalMagic");
            DropColumn("dbo.Characters", "FinalArmor");
            DropColumn("dbo.Characters", "FinalDamage");
        }
    }
}
