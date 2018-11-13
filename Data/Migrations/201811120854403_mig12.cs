namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig12 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "adressid", newName: "address_AddressId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_adressid", newName: "IX_address_AddressId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_address_AddressId", newName: "IX_adressid");
            RenameColumn(table: "dbo.AspNetUsers", name: "address_AddressId", newName: "adressid");
        }
    }
}
