namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class faouzi : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
