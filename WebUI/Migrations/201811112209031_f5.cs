namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f5 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "address_AddressId", newName: "adressid");
            RenameIndex(table: "dbo.Users", name: "IX_address_AddressId", newName: "IX_adressid");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Users", name: "IX_adressid", newName: "IX_address_AddressId");
            RenameColumn(table: "dbo.Users", name: "adressid", newName: "address_AddressId");
        }
    }
}
