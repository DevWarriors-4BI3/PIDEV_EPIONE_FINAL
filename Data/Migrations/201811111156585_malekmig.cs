namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class malekmig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "address_AddressId", "dbo.Addresses");
            DropIndex("dbo.AspNetUsers", new[] { "address_AddressId" });
            AlterColumn("dbo.AspNetUsers", "address_AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "address_AddressId");
            AddForeignKey("dbo.AspNetUsers", "address_AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "address_AddressId", "dbo.Addresses");
            DropIndex("dbo.AspNetUsers", new[] { "address_AddressId" });
            AlterColumn("dbo.AspNetUsers", "address_AddressId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "address_AddressId");
            AddForeignKey("dbo.AspNetUsers", "address_AddressId", "dbo.Addresses", "AddressId");
        }
    }
}
