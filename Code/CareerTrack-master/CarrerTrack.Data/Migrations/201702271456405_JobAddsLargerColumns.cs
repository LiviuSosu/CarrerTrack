namespace CarrerTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobAddsLargerColumns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobAnnouncement", "Content", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.JobAnnouncement", "Rewards", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.JobAnnouncement", "Source", c => c.String(nullable: false, maxLength: 300, unicode: false));
            AlterColumn("dbo.JobAnnouncement", "Contact", c => c.String(maxLength: 300, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobAnnouncement", "Contact", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.JobAnnouncement", "Source", c => c.String(nullable: false, maxLength: 500, unicode: false));
            AlterColumn("dbo.JobAnnouncement", "Rewards", c => c.String(maxLength: 1000, unicode: false));
            AlterColumn("dbo.JobAnnouncement", "Content", c => c.String(maxLength: 1000, unicode: false));
        }
    }
}
