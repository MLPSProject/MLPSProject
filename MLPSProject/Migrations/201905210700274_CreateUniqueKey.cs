namespace MLPSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUniqueKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoanDetails", "RegisteredUserId", "dbo.RegisteredUsers");
            DropForeignKey("dbo.LoanDetails", "UnRegisteredUserId", "dbo.UnRegisteredUsers");
            DropIndex("dbo.LoanDetails", new[] { "RegisteredUserId" });
            DropIndex("dbo.LoanDetails", new[] { "UnRegisteredUserId" });
            AlterColumn("dbo.LoanDetails", "RegisteredUserId", c => c.Int());
            AlterColumn("dbo.LoanDetails", "UnRegisteredUserId", c => c.Int());
            CreateIndex("dbo.LoanDetails", "RegisteredUserId");
            CreateIndex("dbo.LoanDetails", "UnRegisteredUserId");
            CreateIndex("dbo.RegisteredUsers", "vMobile", unique: true, name: "Ix_vMobile");
            CreateIndex("dbo.UnRegisteredUsers", "vMobile", unique: true, name: "Ix_vMobile");
            AddForeignKey("dbo.LoanDetails", "RegisteredUserId", "dbo.RegisteredUsers", "Id");
            AddForeignKey("dbo.LoanDetails", "UnRegisteredUserId", "dbo.UnRegisteredUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanDetails", "UnRegisteredUserId", "dbo.UnRegisteredUsers");
            DropForeignKey("dbo.LoanDetails", "RegisteredUserId", "dbo.RegisteredUsers");
            DropIndex("dbo.UnRegisteredUsers", "Ix_vMobile");
            DropIndex("dbo.RegisteredUsers", "Ix_vMobile");
            DropIndex("dbo.LoanDetails", new[] { "UnRegisteredUserId" });
            DropIndex("dbo.LoanDetails", new[] { "RegisteredUserId" });
            AlterColumn("dbo.LoanDetails", "UnRegisteredUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.LoanDetails", "RegisteredUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.LoanDetails", "UnRegisteredUserId");
            CreateIndex("dbo.LoanDetails", "RegisteredUserId");
            AddForeignKey("dbo.LoanDetails", "UnRegisteredUserId", "dbo.UnRegisteredUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoanDetails", "RegisteredUserId", "dbo.RegisteredUsers", "Id", cascadeDelete: true);
        }
    }
}
