namespace MLPSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordAddedEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "vPassword", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "vPassword");
        }
    }
}
