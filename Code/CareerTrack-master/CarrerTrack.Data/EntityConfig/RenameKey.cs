using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.EntityConfig
{
    public partial class RenameKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Company", "Id", "CompanyId");
        }
    }
}
