namespace MLPSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableColumnForMarketValue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PropertyDetails", "iMarketValue", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PropertyDetails", "iMarketValue", c => c.Int(nullable: false));
        }
    }
}
