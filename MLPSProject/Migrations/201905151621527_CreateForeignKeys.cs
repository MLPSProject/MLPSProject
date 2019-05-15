namespace MLPSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateForeignKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoanDetails", "RegisteredUserId", c => c.Int(nullable: false));
            AddColumn("dbo.LoanDetails", "UnRegisteredUserId", c => c.Int(nullable: false));
            AddColumn("dbo.LoanDetails", "PropertyDetailId", c => c.Int(nullable: false));
            AddColumn("dbo.PropertyDetails", "OfficerId", c => c.Int());
            AddColumn("dbo.PropertyDetails", "InspectorId", c => c.Int());
            AddColumn("dbo.PropertyDetails", "AuthorizerId", c => c.Int());
            CreateIndex("dbo.LoanDetails", "RegisteredUserId");
            CreateIndex("dbo.LoanDetails", "UnRegisteredUserId");
            CreateIndex("dbo.LoanDetails", "PropertyDetailId");
            CreateIndex("dbo.PropertyDetails", "OfficerId");
            CreateIndex("dbo.PropertyDetails", "InspectorId");
            CreateIndex("dbo.PropertyDetails", "AuthorizerId");
            AddForeignKey("dbo.PropertyDetails", "AuthorizerId", "dbo.Employees", "Id");
            AddForeignKey("dbo.PropertyDetails", "InspectorId", "dbo.Employees", "Id");
            AddForeignKey("dbo.PropertyDetails", "OfficerId", "dbo.Employees", "Id");
            AddForeignKey("dbo.LoanDetails", "PropertyDetailId", "dbo.PropertyDetails", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoanDetails", "RegisteredUserId", "dbo.RegisteredUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoanDetails", "UnRegisteredUserId", "dbo.UnRegisteredUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanDetails", "UnRegisteredUserId", "dbo.UnRegisteredUsers");
            DropForeignKey("dbo.LoanDetails", "RegisteredUserId", "dbo.RegisteredUsers");
            DropForeignKey("dbo.LoanDetails", "PropertyDetailId", "dbo.PropertyDetails");
            DropForeignKey("dbo.PropertyDetails", "OfficerId", "dbo.Employees");
            DropForeignKey("dbo.PropertyDetails", "InspectorId", "dbo.Employees");
            DropForeignKey("dbo.PropertyDetails", "AuthorizerId", "dbo.Employees");
            DropIndex("dbo.PropertyDetails", new[] { "AuthorizerId" });
            DropIndex("dbo.PropertyDetails", new[] { "InspectorId" });
            DropIndex("dbo.PropertyDetails", new[] { "OfficerId" });
            DropIndex("dbo.LoanDetails", new[] { "PropertyDetailId" });
            DropIndex("dbo.LoanDetails", new[] { "UnRegisteredUserId" });
            DropIndex("dbo.LoanDetails", new[] { "RegisteredUserId" });
            DropColumn("dbo.PropertyDetails", "AuthorizerId");
            DropColumn("dbo.PropertyDetails", "InspectorId");
            DropColumn("dbo.PropertyDetails", "OfficerId");
            DropColumn("dbo.LoanDetails", "PropertyDetailId");
            DropColumn("dbo.LoanDetails", "UnRegisteredUserId");
            DropColumn("dbo.LoanDetails", "RegisteredUserId");
        }
    }
}
