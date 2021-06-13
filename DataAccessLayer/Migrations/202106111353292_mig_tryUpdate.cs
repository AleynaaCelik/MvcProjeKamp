namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_tryUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drafts", "ReceiverMail", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Drafts", "ReceiverMail", c => c.String(maxLength: 50));
        }
    }
}
