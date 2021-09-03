namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rollers",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 1),
                        Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.Admins", "Roller_RoleId", c => c.Int());
            CreateIndex("dbo.Admins", "Roller_RoleId");
            AddForeignKey("dbo.Admins", "Roller_RoleId", "dbo.Rollers", "RoleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "Roller_RoleId", "dbo.Rollers");
            DropIndex("dbo.Admins", new[] { "Roller_RoleId" });
            DropColumn("dbo.Admins", "Roller_RoleId");
            DropTable("dbo.Rollers");
        }
    }
}
