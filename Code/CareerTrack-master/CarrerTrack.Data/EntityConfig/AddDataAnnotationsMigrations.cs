using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.EntityConfig
{
    public partial class AddDataAnnotationsMigrations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserTask", "Priority", c => c.Int(nullable: false, defaultValue: 1));
        }

        public override void Down()
        {
            AlterColumn("dbo.UserTask", "Priority", c => c.Int());
        }
    }
}
