namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrationv20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Treatements", "TreatementId", "dbo.Steps");
            DropForeignKey("dbo.Steps", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Steps", new[] { "User_Id" });
            RenameColumn(table: "dbo.Disponibilities", name: "User_Id", newName: "Doctor_Id");
            RenameIndex(table: "dbo.Disponibilities", name: "IX_User_Id", newName: "IX_Doctor_Id");
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        SpecialityId = c.Int(nullable: false, identity: true),
                        nomSpecialite = c.String(),
                    })
                .PrimaryKey(t => t.SpecialityId);
            
            CreateTable(
                "dbo.MedicalPaths",
                c => new
                    {
                        MedicalPathId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        Date = c.DateTime(nullable: false),
                        RecomendedDotor_Id = c.String(maxLength: 128),
                        Speciality_SpecialityId = c.Int(),
                    })
                .PrimaryKey(t => t.MedicalPathId)
                .ForeignKey("dbo.AspNetUsers", t => t.RecomendedDotor_Id)
                .ForeignKey("dbo.Specialities", t => t.Speciality_SpecialityId)
                .Index(t => t.RecomendedDotor_Id)
                .Index(t => t.Speciality_SpecialityId);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        sentAt = c.DateTime(nullable: false),
                        state = c.Boolean(nullable: false),
                        message = c.String(),
                        recever_Id = c.String(maxLength: 128),
                        sender_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ChatId)
                .ForeignKey("dbo.AspNetUsers", t => t.recever_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.sender_Id)
                .Index(t => t.recever_Id)
                .Index(t => t.sender_Id);
            
            CreateTable(
                "dbo.Fora",
                c => new
                    {
                        ForumId = c.Int(nullable: false, identity: true),
                        sentAt = c.DateTime(nullable: false),
                        subject = c.String(),
                        subjectCreater_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ForumId)
                .ForeignKey("dbo.AspNetUsers", t => t.subjectCreater_Id)
                .Index(t => t.subjectCreater_Id);
            
            AddColumn("dbo.AspNetUsers", "Speciality_SpecialityId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "pathId_MedicalPathId", c => c.Int());
            AddColumn("dbo.Disponibilities", "State", c => c.Boolean(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Speciality_SpecialityId");
            CreateIndex("dbo.AspNetUsers", "pathId_MedicalPathId");
            AddForeignKey("dbo.AspNetUsers", "Speciality_SpecialityId", "dbo.Specialities", "SpecialityId");
            AddForeignKey("dbo.Treatements", "TreatementId", "dbo.MedicalPaths", "MedicalPathId");
            AddForeignKey("dbo.AspNetUsers", "pathId_MedicalPathId", "dbo.MedicalPaths", "MedicalPathId");
            DropColumn("dbo.AspNetUsers", "Speciality");
            DropTable("dbo.Steps");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        StepId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 50),
                        Date = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.StepId);
            
            AddColumn("dbo.AspNetUsers", "Speciality", c => c.String());
            DropForeignKey("dbo.Fora", "subjectCreater_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chats", "sender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chats", "recever_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "pathId_MedicalPathId", "dbo.MedicalPaths");
            DropForeignKey("dbo.Treatements", "TreatementId", "dbo.MedicalPaths");
            DropForeignKey("dbo.MedicalPaths", "Speciality_SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.MedicalPaths", "RecomendedDotor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Speciality_SpecialityId", "dbo.Specialities");
            DropIndex("dbo.Fora", new[] { "subjectCreater_Id" });
            DropIndex("dbo.Chats", new[] { "sender_Id" });
            DropIndex("dbo.Chats", new[] { "recever_Id" });
            DropIndex("dbo.MedicalPaths", new[] { "Speciality_SpecialityId" });
            DropIndex("dbo.MedicalPaths", new[] { "RecomendedDotor_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "pathId_MedicalPathId" });
            DropIndex("dbo.AspNetUsers", new[] { "Speciality_SpecialityId" });
            DropColumn("dbo.Disponibilities", "State");
            DropColumn("dbo.AspNetUsers", "pathId_MedicalPathId");
            DropColumn("dbo.AspNetUsers", "Speciality_SpecialityId");
            DropTable("dbo.Fora");
            DropTable("dbo.Chats");
            DropTable("dbo.MedicalPaths");
            DropTable("dbo.Specialities");
            RenameIndex(table: "dbo.Disponibilities", name: "IX_Doctor_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Disponibilities", name: "Doctor_Id", newName: "User_Id");
            CreateIndex("dbo.Steps", "User_Id");
            AddForeignKey("dbo.Steps", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Treatements", "TreatementId", "dbo.Steps", "StepId");
        }
    }
}
