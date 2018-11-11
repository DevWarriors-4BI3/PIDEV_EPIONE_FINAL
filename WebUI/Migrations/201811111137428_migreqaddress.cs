namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migreqaddress : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.doctor_Id)
                .ForeignKey("dbo.Users", t => t.patient_Id)
                .Index(t => t.User_Id)
                .Index(t => t.doctor_Id)
                .Index(t => t.patient_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        firstName = c.String(nullable: false, maxLength: 50),
                        lastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        address_AddressId = c.Int(nullable: false),
                        Speciality_SpecialityId = c.Int(),
                        pathId_MedicalPathId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.address_AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Specialities", t => t.Speciality_SpecialityId)
                .ForeignKey("dbo.MedicalPaths", t => t.pathId_MedicalPathId)
                .Index(t => t.address_AddressId)
                .Index(t => t.Speciality_SpecialityId)
                .Index(t => t.pathId_MedicalPathId);
            
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
                .ForeignKey("dbo.Users", t => t.doctor_Id)
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
                .ForeignKey("dbo.Users", t => t.RecomendedDotor_Id)
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
            
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "patient_Id", "dbo.Users");
            DropForeignKey("dbo.Appointments", "doctor_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "pathId_MedicalPathId", "dbo.MedicalPaths");
            DropForeignKey("dbo.Treatements", "TreatementId", "dbo.MedicalPaths");
            DropForeignKey("dbo.MedicalPaths", "Speciality_SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.MedicalPaths", "RecomendedDotor_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Speciality_SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.Disponibilities", "doctor_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "address_AddressId", "dbo.Addresses");
            DropIndex("dbo.Treatements", new[] { "TreatementId" });
            DropIndex("dbo.MedicalPaths", new[] { "Speciality_SpecialityId" });
            DropIndex("dbo.MedicalPaths", new[] { "RecomendedDotor_Id" });
            DropIndex("dbo.Disponibilities", new[] { "doctor_Id" });
            DropIndex("dbo.Users", new[] { "pathId_MedicalPathId" });
            DropIndex("dbo.Users", new[] { "Speciality_SpecialityId" });
            DropIndex("dbo.Users", new[] { "address_AddressId" });
            DropIndex("dbo.Appointments", new[] { "patient_Id" });
            DropIndex("dbo.Appointments", new[] { "doctor_Id" });
            DropIndex("dbo.Appointments", new[] { "User_Id" });
            DropTable("dbo.Treatements");
            DropTable("dbo.MedicalPaths");
            DropTable("dbo.Specialities");
            DropTable("dbo.Disponibilities");
            DropTable("dbo.Addresses");
            DropTable("dbo.Users");
            DropTable("dbo.Appointments");
        }
    }
}
