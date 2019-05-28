namespace MLPSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDataBaseTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoanDetails", "PropertyDetailId", "dbo.PropertyDetails");
            DropForeignKey("dbo.LoanDetails", "RegisteredUserId", "dbo.RegisteredUsers");
            DropForeignKey("dbo.LoanDetails", "UnRegisteredUserId", "dbo.UnRegisteredUsers");
            DropIndex("dbo.LoanDetails", new[] { "RegisteredUserId" });
            DropIndex("dbo.LoanDetails", new[] { "UnRegisteredUserId" });
            DropIndex("dbo.LoanDetails", new[] { "PropertyDetailId" });
            AlterColumn("dbo.LoanDetails", "RegisteredUserId", c => c.Int());
            AlterColumn("dbo.LoanDetails", "UnRegisteredUserId", c => c.Int());
            AlterColumn("dbo.LoanDetails", "PropertyDetailId", c => c.Int());
            AlterColumn("dbo.PropertyDetails", "iMarketValue", c => c.Int());
            AlterColumn("dbo.RegisteredUsers", "vMobile", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.UnRegisteredUsers", "vMobile", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            CreateIndex("dbo.LoanDetails", "RegisteredUserId");
            CreateIndex("dbo.LoanDetails", "UnRegisteredUserId");
            CreateIndex("dbo.LoanDetails", "PropertyDetailId");
            CreateIndex("dbo.RegisteredUsers", "vMobile", unique: true, name: "Ix_vMobile");
            CreateIndex("dbo.UnRegisteredUsers", "vMobile", unique: true, name: "Ix_vMobile");
            AddForeignKey("dbo.LoanDetails", "PropertyDetailId", "dbo.PropertyDetails", "Id");
            AddForeignKey("dbo.LoanDetails", "RegisteredUserId", "dbo.RegisteredUsers", "Id");
            AddForeignKey("dbo.LoanDetails", "UnRegisteredUserId", "dbo.UnRegisteredUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanDetails", "UnRegisteredUserId", "dbo.UnRegisteredUsers");
            DropForeignKey("dbo.LoanDetails", "RegisteredUserId", "dbo.RegisteredUsers");
            DropForeignKey("dbo.LoanDetails", "PropertyDetailId", "dbo.PropertyDetails");
            DropIndex("dbo.UnRegisteredUsers", "Ix_vMobile");
            DropIndex("dbo.RegisteredUsers", "Ix_vMobile");
            DropIndex("dbo.LoanDetails", new[] { "PropertyDetailId" });
            DropIndex("dbo.LoanDetails", new[] { "UnRegisteredUserId" });
            DropIndex("dbo.LoanDetails", new[] { "RegisteredUserId" });
            AlterColumn("dbo.UnRegisteredUsers", "vMobile", c => c.String(nullable: false));
            AlterColumn("dbo.RegisteredUsers", "vMobile", c => c.String(nullable: false));
            AlterColumn("dbo.PropertyDetails", "iMarketValue", c => c.Int(nullable: false));
            AlterColumn("dbo.LoanDetails", "PropertyDetailId", c => c.Int(nullable: false));
            AlterColumn("dbo.LoanDetails", "UnRegisteredUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.LoanDetails", "RegisteredUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.LoanDetails", "PropertyDetailId");
            CreateIndex("dbo.LoanDetails", "UnRegisteredUserId");
            CreateIndex("dbo.LoanDetails", "RegisteredUserId");
            AddForeignKey("dbo.LoanDetails", "UnRegisteredUserId", "dbo.UnRegisteredUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoanDetails", "RegisteredUserId", "dbo.RegisteredUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoanDetails", "PropertyDetailId", "dbo.PropertyDetails", "Id", cascadeDelete: true);
        }
    }
}
