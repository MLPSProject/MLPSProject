namespace MLPSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropColumns : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PropertyDetails", "IdProof");
            DropColumn("dbo.PropertyDetails", "AddressProof");
            DropColumn("dbo.PropertyDetails", "PropertyAgreement");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PropertyDetails", "PropertyAgreement", c => c.String(nullable: false));
            AddColumn("dbo.PropertyDetails", "AddressProof", c => c.String(nullable: false));
            AddColumn("dbo.PropertyDetails", "IdProof", c => c.String(nullable: false));
        }
    }
}
