namespace LucyManager.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipamentos",
                c => new
                    {
                        EquipamentoId = c.Int(nullable: false, identity: true),
                        Patrimonio = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        DataAquisicao = c.DateTime(nullable: false),
                        DataManutencao = c.DateTime(nullable: false),
                        DataProximaManutencao = c.DateTime(nullable: false),
                        LocalOrigemId = c.Guid(nullable: false),
                        LocalDestinoId = c.Guid(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EquipamentoId);
            
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        EventoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EventoId);
            
            CreateTable(
                "dbo.Locais",
                c => new
                    {
                        LocalId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        NomeAbreviado = c.String(),
                        Descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LocalId);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        ReservaId = c.Int(nullable: false, identity: true),
                        DataInicialReserva = c.DateTime(nullable: false),
                        DataFinalReserva = c.DateTime(nullable: false),
                        LocalId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        EventoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ReservaId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.String(nullable: false, maxLength: 128),
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
                        NumeroCelular = c.String(),
                        NumeroTelefone = c.String(),
                        EAdmin = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Usuarios", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "IdentityUser_Id", "dbo.Usuarios");
            DropForeignKey("dbo.UserLogins", "IdentityUser_Id", "dbo.Usuarios");
            DropForeignKey("dbo.UserClaims", "IdentityUser_Id", "dbo.Usuarios");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.UserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Usuarios", "UserNameIndex");
            DropIndex("dbo.UserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Usuarios");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Reservas");
            DropTable("dbo.Locais");
            DropTable("dbo.Eventos");
            DropTable("dbo.Equipamentos");
        }
    }
}