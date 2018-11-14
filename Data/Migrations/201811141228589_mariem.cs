namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mariem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        country = c.String(nullable: false, maxLength: 50),
                        city = c.String(nullable: false, maxLength: 50),
                        Street = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        appointementDate = c.DateTime(nullable: false),
                        reason = c.String(nullable: false, maxLength: 50),
                        state = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                        doctor_Id = c.String(maxLength: 128),
                        patient_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.doctor_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.patient_Id)
                .Index(t => t.User_Id)
                .Index(t => t.doctor_Id)
                .Index(t => t.patient_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        firstName = c.String(nullable: false, maxLength: 50),
                        lastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        address_AddressId = c.Int(nullable: false),
                        Speciality_SpecialityId = c.Int(),
                        pathId_MedicalPathId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.address_AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Specialities", t => t.Speciality_SpecialityId)
                .ForeignKey("dbo.MedicalPaths", t => t.pathId_MedicalPathId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.address_AddressId)
                .Index(t => t.Speciality_SpecialityId)
                .Index(t => t.pathId_MedicalPathId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Disponibilities",
                c => new
                    {
                        DisponibilityId = c.Int(nullable: false, identity: true),
                        startTimeOfDisponibility = c.DateTime(nullable: false),
                        endTimeOfDisponibility = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                        doctor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DisponibilityId)
                .ForeignKey("dbo.AspNetUsers", t => t.doctor_Id)
                .Index(t => t.doctor_Id);
            
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
                "dbo.Treatements",
                c => new
                    {
                        TreatementId = c.Int(nullable: false),
                        description = c.String(nullable: false, maxLength: 50),
                        daysDuration = c.Int(nullable: false),
                        isValitaded = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TreatementId)
                .ForeignKey("dbo.MedicalPaths", t => t.TreatementId)
                .Index(t => t.TreatementId);
            
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
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        photo = c.String(),
                        appointment_AppointmentId = c.Int(),
                    })
                .PrimaryKey(t => t.ReportId)
                .ForeignKey("dbo.Appointments", t => t.appointment_AppointmentId)
                .Index(t => t.appointment_AppointmentId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Reports", "appointment_AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Fora", "subjectCreater_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chats", "sender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chats", "recever_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Appointments", "patient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Appointments", "doctor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "pathId_MedicalPathId", "dbo.MedicalPaths");
            DropForeignKey("dbo.Treatements", "TreatementId", "dbo.MedicalPaths");
            DropForeignKey("dbo.MedicalPaths", "Speciality_SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.MedicalPaths", "RecomendedDotor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Speciality_SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.Disponibilities", "doctor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Appointments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "address_AddressId", "dbo.Addresses");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Reports", new[] { "appointment_AppointmentId" });
            DropIndex("dbo.Fora", new[] { "subjectCreater_Id" });
            DropIndex("dbo.Chats", new[] { "sender_Id" });
            DropIndex("dbo.Chats", new[] { "recever_Id" });
            DropIndex("dbo.Treatements", new[] { "TreatementId" });
            DropIndex("dbo.MedicalPaths", new[] { "Speciality_SpecialityId" });
            DropIndex("dbo.MedicalPaths", new[] { "RecomendedDotor_Id" });
            DropIndex("dbo.Disponibilities", new[] { "doctor_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "pathId_MedicalPathId" });
            DropIndex("dbo.AspNetUsers", new[] { "Speciality_SpecialityId" });
            DropIndex("dbo.AspNetUsers", new[] { "address_AddressId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Appointments", new[] { "patient_Id" });
            DropIndex("dbo.Appointments", new[] { "doctor_Id" });
            DropIndex("dbo.Appointments", new[] { "User_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Reports");
            DropTable("dbo.Fora");
            DropTable("dbo.Events");
            DropTable("dbo.Chats");
            DropTable("dbo.Treatements");
            DropTable("dbo.MedicalPaths");
            DropTable("dbo.Specialities");
            DropTable("dbo.Disponibilities");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Appointments");
            DropTable("dbo.Addresses");
        }
    }
}
