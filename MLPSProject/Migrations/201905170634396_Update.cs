namespace MLPSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoanDetails", "vName", c => c.String(nullable: false));
            AlterColumn("dbo.LoanDetails", "vMobile", c => c.String(nullable: false));
            AlterColumn("dbo.LoanDetails", "vEmail", c => c.String(nullable: false));
            AlterColumn("dbo.LoanDetails", "vCity", c => c.String(nullable: false));
            AlterColumn("dbo.LoanDetails", "vOccupation", c => c.String(nullable: false));
            AlterColumn("dbo.LoanDetails", "vAddress", c => c.String(nullable: false));
            AlterColumn("dbo.LoanDetails", "dtLoanAppliedDate", c => c.String(nullable: false));
            AlterColumn("dbo.PropertyDetails", "vPropertyHolderName", c => c.String(nullable: false));
            AlterColumn("dbo.PropertyDetails", "vPropertyType", c => c.String(nullable: false));
            AlterColumn("dbo.PropertyDetails", "PropertyAddress", c => c.String(nullable: false));
            AlterColumn("dbo.PropertyDetails", "IdProof", c => c.String(nullable: false));
            AlterColumn("dbo.PropertyDetails", "AddressProof", c => c.String(nullable: false));
            AlterColumn("dbo.PropertyDetails", "PropertyAgreement", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PropertyDetails", "PropertyAgreement", c => c.String());
            AlterColumn("dbo.PropertyDetails", "AddressProof", c => c.String());
            AlterColumn("dbo.PropertyDetails", "IdProof", c => c.String());
            AlterColumn("dbo.PropertyDetails", "PropertyAddress", c => c.String());
            AlterColumn("dbo.PropertyDetails", "vPropertyType", c => c.String());
            AlterColumn("dbo.PropertyDetails", "vPropertyHolderName", c => c.String());
            AlterColumn("dbo.LoanDetails", "dtLoanAppliedDate", c => c.String());
            AlterColumn("dbo.LoanDetails", "vAddress", c => c.String());
            AlterColumn("dbo.LoanDetails", "vOccupation", c => c.String());
            AlterColumn("dbo.LoanDetails", "vCity", c => c.String());
            AlterColumn("dbo.LoanDetails", "vEmail", c => c.String());
            AlterColumn("dbo.LoanDetails", "vMobile", c => c.String());
            AlterColumn("dbo.LoanDetails", "vName", c => c.String());
        }
    }
}
