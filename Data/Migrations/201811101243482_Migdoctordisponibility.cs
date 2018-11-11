namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migdoctordisponibility : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Disponibilities", new[] { "Doctor_Id" });
            CreateIndex("dbo.Disponibilities", "doctor_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Disponibilities", new[] { "doctor_Id" });
            CreateIndex("dbo.Disponibilities", "Doctor_Id");
        }
    }
}
