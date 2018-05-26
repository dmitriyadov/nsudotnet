namespace adov_db_15202.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "ProductID", "dbo.Product");
            DropForeignKey("dbo.ProvidersPrice", "ProductID", "dbo.Product");
            DropForeignKey("dbo.StoresProduct", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Sale", "ProductID", "dbo.Product");
            DropPrimaryKey("dbo.Product");
            AddColumn("dbo.Product", "ID", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Product", "ID");
            AddForeignKey("dbo.Order", "ProductID", "dbo.Product", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProvidersPrice", "ProductID", "dbo.Product", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StoresProduct", "ProductID", "dbo.Product", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Sale", "ProductID", "dbo.Product", "ID", cascadeDelete: true);
            DropColumn("dbo.Product", "ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "ProductID", c => c.Long(nullable: false, identity: true));
            DropForeignKey("dbo.Sale", "ProductID", "dbo.Product");
            DropForeignKey("dbo.StoresProduct", "ProductID", "dbo.Product");
            DropForeignKey("dbo.ProvidersPrice", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Order", "ProductID", "dbo.Product");
            DropPrimaryKey("dbo.Product");
            DropColumn("dbo.Product", "ID");
            AddPrimaryKey("dbo.Product", "ProductID");
            AddForeignKey("dbo.Sale", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.StoresProduct", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.ProvidersPrice", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.Order", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
        }
    }
}
