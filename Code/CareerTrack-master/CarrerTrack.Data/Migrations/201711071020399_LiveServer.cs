namespace CarrerTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LiveServer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobAnnouncement", "IsArchieved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobAnnouncement", "IsArchieved");
        }
    }
}
