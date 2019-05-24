namespace MLPSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUniqueKey : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.RegisteredUsers", "Ix_vMobile");
            CreateIndex("dbo.RegisteredUsers", "vMobile", unique: true, name: "Ix_vMobile");
        }
        
        public override void Down()
        {
            DropIndex("dbo.RegisteredUsers", "Ix_vMobile");
            CreateIndex("dbo.RegisteredUsers", "vMobile", unique: true, name: "Ix_vMobile");
        }
    }
}
