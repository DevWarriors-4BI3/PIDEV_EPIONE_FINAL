namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "address_AddressId", "dbo.Addresses");
            DropIndex("dbo.AspNetUsers", new[] { "address_AddressId" });
            DropIndex("dbo.Disponibilities", new[] { "Doctor_Id" });
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ComID = c.Int(nullable: false, identity: true),
                        CommentMsg = c.String(),
                        CommentedDate = c.DateTime(),
                        PostID = c.Int(),
                        UserID = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ComID)
                .ForeignKey("dbo.Posts", t => t.PostID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.PostID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Message = c.String(),
                        PostedDate = c.DateTime(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Themecolor = c.String(),
                        IsFullDay = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            AlterColumn("dbo.AspNetUsers", "address_AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "address_AddressId");
            CreateIndex("dbo.Disponibilities", "doctor_Id");
            AddForeignKey("dbo.AspNetUsers", "address_AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropIndex("dbo.Disponibilities", new[] { "doctor_Id" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropIndex("dbo.AspNetUsers", new[] { "address_AddressId" });
            AlterColumn("dbo.AspNetUsers", "address_AddressId", c => c.Int());
            DropTable("dbo.Events");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            CreateIndex("dbo.Disponibilities", "Doctor_Id");
            CreateIndex("dbo.AspNetUsers", "address_AddressId");
            AddForeignKey("dbo.AspNetUsers", "address_AddressId", "dbo.Addresses", "AddressId");
        }
    }
}
