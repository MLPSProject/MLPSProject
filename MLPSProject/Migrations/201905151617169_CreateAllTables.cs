namespace MLPSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAllTables : DbMigration
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
                    })
                .PrimaryKey(t => t.Id);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropTable("dbo.UnRegisteredUsers");
            DropTable("dbo.RegisteredUsers");
            DropTable("dbo.PropertyDetails");
            DropTable("dbo.LoanDetails");
            DropTable("dbo.Employees");
        }
    }
}
