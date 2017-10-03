namespace CarrerTrack.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class BrkineLinkIsNowOptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Article", "BrokenLink", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Article", "BrokenLink", c => c.Boolean(nullable: false));
        }
    }
}
