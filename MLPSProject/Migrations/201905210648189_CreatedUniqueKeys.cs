namespace MLPSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedUniqueKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoanDetails", "RegisteredUserId", "dbo.RegisteredUsers");
            DropForeignKey("dbo.LoanDetails", "UnRegisteredUserId", "dbo.UnRegisteredUsers");
            DropIndex("dbo.LoanDetails", new[] { "RegisteredUserId" });
            DropIndex("dbo.LoanDetails", new[] { "UnRegisteredUserId" });
            AlterColumn("dbo.LoanDetails", "RegisteredUserId", c => c.Int());
            AlterColumn("dbo.LoanDetails", "UnRegisteredUserId", c => c.Int());
            CreateIndex("dbo.Employees", "vMobile", unique: true, name: "Ix_vMobile");
            CreateIndex("dbo.Employees", "vEmailID", unique: true, name: "Ix_vEmailID");
            CreateIndex("dbo.LoanDetails", "vMobile", unique: true, name: "Ix_vMobile");
            CreateIndex("dbo.LoanDetails", "vEmail", unique: true, name: "Ix_vEmail");
            CreateIndex("dbo.LoanDetails", "RegisteredUserId");
            CreateIndex("dbo.LoanDetails", "UnRegisteredUserId");
            CreateIndex("dbo.RegisteredUsers", "vMobile", unique: true, name: "Ix_vMobile");
            CreateIndex("dbo.RegisteredUsers", "vEmailID", unique: true, name: "Ix_vEmailID");
            CreateIndex("dbo.UnRegisteredUsers", "vMobile", unique: true, name: "Ix_vMobile");
            CreateIndex("dbo.UnRegisteredUsers", "vEmailID", unique: true, name: "Ix_vEmailID");
            AddForeignKey("dbo.LoanDetails", "RegisteredUserId", "dbo.RegisteredUsers", "Id");
            AddForeignKey("dbo.LoanDetails", "UnRegisteredUserId", "dbo.UnRegisteredUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanDetails", "UnRegisteredUserId", "dbo.UnRegisteredUsers");
            DropForeignKey("dbo.LoanDetails", "RegisteredUserId", "dbo.RegisteredUsers");
            DropIndex("dbo.UnRegisteredUsers", "Ix_vEmailID");
            DropIndex("dbo.UnRegisteredUsers", "Ix_vMobile");
            DropIndex("dbo.RegisteredUsers", "Ix_vEmailID");
            DropIndex("dbo.RegisteredUsers", "Ix_vMobile");
            DropIndex("dbo.LoanDetails", new[] { "UnRegisteredUserId" });
            DropIndex("dbo.LoanDetails", new[] { "RegisteredUserId" });
            DropIndex("dbo.LoanDetails", "Ix_vEmail");
            DropIndex("dbo.LoanDetails", "Ix_vMobile");
            DropIndex("dbo.Employees", "Ix_vEmailID");
            DropIndex("dbo.Employees", "Ix_vMobile");
            AlterColumn("dbo.LoanDetails", "UnRegisteredUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.LoanDetails", "RegisteredUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.LoanDetails", "UnRegisteredUserId");
            CreateIndex("dbo.LoanDetails", "RegisteredUserId");
            AddForeignKey("dbo.LoanDetails", "UnRegisteredUserId", "dbo.UnRegisteredUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoanDetails", "RegisteredUserId", "dbo.RegisteredUsers", "Id", cascadeDelete: true);
        }
    }
}
