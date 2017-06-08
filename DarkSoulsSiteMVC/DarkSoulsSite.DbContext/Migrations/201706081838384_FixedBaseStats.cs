namespace DarkSoulsSite.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedBaseStats : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Armors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BaseArmor = c.Int(nullable: false),
                        FireDefense = c.Int(nullable: false),
                        IceDefense = c.Int(nullable: false),
                        LightningDefense = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Level = c.Int(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bosses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BaseDamage = c.Int(nullable: false),
                        BaseArmor = c.Int(nullable: false),
                        FireDefense = c.Int(nullable: false),
                        IceDefense = c.Int(nullable: false),
                        LightningDefense = c.Int(nullable: false),
                        BleedDefence = c.Boolean(nullable: false),
                        PoisonDefence = c.Boolean(nullable: false),
                        Reward = c.String(),
                        Rating = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Level = c.Int(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        CharDamage = c.Int(nullable: false),
                        CharArmor = c.Int(nullable: false),
                        CharMagic = c.Int(nullable: false),
                        WeaponId = c.String(nullable: false, maxLength: 128),
                        ArmorId = c.String(nullable: false, maxLength: 128),
                        MagicId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        Level = c.Int(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Armors", t => t.ArmorId, cascadeDelete: true)
                .ForeignKey("dbo.Magics", t => t.MagicId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Weapons", t => t.WeaponId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.WeaponId)
                .Index(t => t.ArmorId)
                .Index(t => t.MagicId);
            
            CreateTable(
                "dbo.Magics",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BaseMagic = c.Int(nullable: false),
                        Fire = c.Int(nullable: false),
                        Ice = c.Int(nullable: false),
                        Lightning = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Level = c.Int(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Weapons",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BaseDamage = c.Int(nullable: false),
                        Bleed = c.Boolean(nullable: false),
                        Poison = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Level = c.Int(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fights",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CharacterId = c.String(maxLength: 128),
                        BossId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bosses", t => t.BossId)
                .ForeignKey("dbo.Characters", t => t.CharacterId)
                .Index(t => t.CharacterId)
                .Index(t => t.BossId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Fights", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.Fights", "BossId", "dbo.Bosses");
            DropForeignKey("dbo.Characters", "WeaponId", "dbo.Weapons");
            DropForeignKey("dbo.Characters", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Characters", "MagicId", "dbo.Magics");
            DropForeignKey("dbo.Characters", "ArmorId", "dbo.Armors");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Fights", new[] { "BossId" });
            DropIndex("dbo.Fights", new[] { "CharacterId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Characters", new[] { "MagicId" });
            DropIndex("dbo.Characters", new[] { "ArmorId" });
            DropIndex("dbo.Characters", new[] { "WeaponId" });
            DropIndex("dbo.Characters", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Fights");
            DropTable("dbo.Weapons");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Magics");
            DropTable("dbo.Characters");
            DropTable("dbo.Bosses");
            DropTable("dbo.Armors");
        }
    }
}
