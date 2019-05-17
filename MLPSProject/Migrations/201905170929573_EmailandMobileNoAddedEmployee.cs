namespace MLPSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailandMobileNoAddedEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "vMobile", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "vEmailID", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "vEmailID");
            DropColumn("dbo.Employees", "vMobile");
        }
    }
}
