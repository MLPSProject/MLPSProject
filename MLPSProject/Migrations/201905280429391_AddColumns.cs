namespace MLPSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertyDetails", "IdProof", c => c.Binary(nullable: false));
            AddColumn("dbo.PropertyDetails", "AddressProof", c => c.Binary(nullable: false));
            AddColumn("dbo.PropertyDetails", "PropertyAgreement", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PropertyDetails", "PropertyAgreement");
            DropColumn("dbo.PropertyDetails", "AddressProof");
            DropColumn("dbo.PropertyDetails", "IdProof");
        }
    }
}
