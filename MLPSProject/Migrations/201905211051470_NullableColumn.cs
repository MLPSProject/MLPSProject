namespace MLPSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoanDetails", "PropertyDetailId", "dbo.PropertyDetails");
            DropIndex("dbo.LoanDetails", new[] { "PropertyDetailId" });
            AlterColumn("dbo.LoanDetails", "PropertyDetailId", c => c.Int());
            CreateIndex("dbo.LoanDetails", "PropertyDetailId");
            AddForeignKey("dbo.LoanDetails", "PropertyDetailId", "dbo.PropertyDetails", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanDetails", "PropertyDetailId", "dbo.PropertyDetails");
            DropIndex("dbo.LoanDetails", new[] { "PropertyDetailId" });
            AlterColumn("dbo.LoanDetails", "PropertyDetailId", c => c.Int(nullable: false));
            CreateIndex("dbo.LoanDetails", "PropertyDetailId");
            AddForeignKey("dbo.LoanDetails", "PropertyDetailId", "dbo.PropertyDetails", "Id", cascadeDelete: true);
        }
    }
}
