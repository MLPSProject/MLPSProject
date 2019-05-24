namespace MLPSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUniqueUnReg : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UnRegisteredUsers", "Ix_vMobile");
            CreateIndex("dbo.UnRegisteredUsers", "vMobile", unique: true, name: "Ix_vMobile");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UnRegisteredUsers", "Ix_vMobile");
            CreateIndex("dbo.UnRegisteredUsers", "vMobile", unique: true, name: "Ix_vMobile");
        }
    }
}
