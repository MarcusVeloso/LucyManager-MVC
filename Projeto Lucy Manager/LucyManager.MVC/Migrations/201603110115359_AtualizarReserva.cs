namespace LucyManager.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizarReserva : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Eventos", "Reservas_ReservaId", c => c.Int());
            AddColumn("dbo.Locais", "Reservas_ReservaId", c => c.Int());
            AddColumn("dbo.Usuarios", "Reservas_ReservaId", c => c.Int());
            CreateIndex("dbo.Eventos", "Reservas_ReservaId");
            CreateIndex("dbo.Locais", "Reservas_ReservaId");
            CreateIndex("dbo.Usuarios", "Reservas_ReservaId");
            AddForeignKey("dbo.Eventos", "Reservas_ReservaId", "dbo.Reservas", "ReservaId");
            AddForeignKey("dbo.Locais", "Reservas_ReservaId", "dbo.Reservas", "ReservaId");
            AddForeignKey("dbo.Usuarios", "Reservas_ReservaId", "dbo.Reservas", "ReservaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "Reservas_ReservaId", "dbo.Reservas");
            DropForeignKey("dbo.Locais", "Reservas_ReservaId", "dbo.Reservas");
            DropForeignKey("dbo.Eventos", "Reservas_ReservaId", "dbo.Reservas");
            DropIndex("dbo.Usuarios", new[] { "Reservas_ReservaId" });
            DropIndex("dbo.Locais", new[] { "Reservas_ReservaId" });
            DropIndex("dbo.Eventos", new[] { "Reservas_ReservaId" });
            DropColumn("dbo.Usuarios", "Reservas_ReservaId");
            DropColumn("dbo.Locais", "Reservas_ReservaId");
            DropColumn("dbo.Eventos", "Reservas_ReservaId");
        }
    }
}
