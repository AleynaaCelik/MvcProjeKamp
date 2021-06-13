namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_message1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        TalentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        About = c.String(),
                        TalentName = c.String(),
                        Percent = c.String(),
                    })
                .PrimaryKey(t => t.TalentID);
            
            AddColumn("dbo.Messages", "MessageStatus", c => c.String());
            AddColumn("dbo.Messages", "MessageRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageRead");
            DropColumn("dbo.Messages", "MessageStatus");
            DropTable("dbo.Talents");
        }
    }
}
