namespace MLPSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        vName = c.String(nullable: false, maxLength: 100),
                        vDesignation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoanDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        vName = c.String(),
                        vMobile = c.String(),
                        vEmail = c.String(),
                        vCity = c.String(),
                        iAge = c.Int(nullable: false),
                        vOccupation = c.String(),
                        vAddress = c.String(),
                        dLoanAmount = c.Double(nullable: false),
                        iRateOfInterest = c.Int(nullable: false),
                        dtLoanAppliedDate = c.String(),
                        dtLoanApprovedDate = c.String(),
                        iDuration = c.Int(nullable: false),
                        vStatus = c.String(),
                        RegisteredUserId = c.Int(nullable: false),
                        UnRegisteredUserId = c.Int(nullable: false),
                        PropertyDetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyDetails", t => t.PropertyDetailId, cascadeDelete: true)
                .ForeignKey("dbo.RegisteredUsers", t => t.RegisteredUserId, cascadeDelete: true)
                .ForeignKey("dbo.UnRegisteredUsers", t => t.UnRegisteredUserId, cascadeDelete: true)
                .Index(t => t.RegisteredUserId)
                .Index(t => t.UnRegisteredUserId)
                .Index(t => t.PropertyDetailId);
            
            CreateTable(
                "dbo.PropertyDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        vPropertyHolderName = c.String(),
                        vPropertyType = c.String(),
                        PropertyAddress = c.String(),
                        iMarketValue = c.Int(nullable: false),
                        vRemarks = c.String(),
                        IdProof = c.String(),
                        AddressProof = c.String(),
                        PropertyAgreement = c.String(),
                        OfficerId = c.Int(),
                        InspectorId = c.Int(),
                        AuthorizerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.AuthorizerId)
                .ForeignKey("dbo.Employees", t => t.InspectorId)
                .ForeignKey("dbo.Employees", t => t.OfficerId)
                .Index(t => t.OfficerId)
                .Index(t => t.InspectorId)
                .Index(t => t.AuthorizerId);
            
            CreateTable(
                "dbo.RegisteredUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        dtDateOfRegistration = c.String(nullable: false),
                        vFirstName = c.String(nullable: false, maxLength: 100),
                        vLastName = c.String(nullable: false, maxLength: 100),
                        dtDOB = c.String(nullable: false),
                        vGender = c.String(nullable: false),
                        vMobile = c.String(nullable: false),
                        vEmailID = c.String(nullable: false, maxLength: 100),
                        vOccupation = c.String(nullable: false, maxLength: 100),
                        vCity = c.String(nullable: false, maxLength: 100),
                        vAddress = c.String(nullable: false, maxLength: 100),
                        vPassword = c.String(nullable: false, maxLength: 100),
                        vConfirmPassword = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnRegisteredUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        dtDateOfRegistration = c.String(nullable: false, maxLength: 100),
                        vFirstName = c.String(nullable: false, maxLength: 100),
                        vLastName = c.String(nullable: false, maxLength: 100),
                        dtDOB = c.String(nullable: false),
                        vGender = c.String(nullable: false),
                        vMobile = c.String(nullable: false),
                        vEmailID = c.String(nullable: false, maxLength: 100),
                        vOccupation = c.String(nullable: false, maxLength: 100),
                        vCity = c.String(nullable: false, maxLength: 100),
                        vAddress = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropTable("dbo.UnRegisteredUsers");
            DropTable("dbo.RegisteredUsers");
            DropTable("dbo.PropertyDetails");
            DropTable("dbo.LoanDetails");
            DropTable("dbo.Employees");
        }
    }
}
