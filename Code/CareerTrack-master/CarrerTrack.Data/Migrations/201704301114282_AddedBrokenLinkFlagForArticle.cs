namespace CarrerTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBrokenLinkFlagForArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Article", "BrokenLink", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Article", "BrokenLink");
        }
    }
}
