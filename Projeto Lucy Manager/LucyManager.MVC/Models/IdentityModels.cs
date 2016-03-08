using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace LucyManager.MVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Celular")]
        public string NumeroCelular { get; set; }

        [Required]
        [Display(Name = "Fone")]
        public string NumeroTelefone { get; set; }
        
        [Display(Name = "Administrador")]
        public bool EAdmin { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class LucyManagerDbContext : IdentityDbContext<ApplicationUser>
    {
        public LucyManagerDbContext()
            : base("LucyManagerDb", throwIfV1Schema: false)
        {
        }

        public DbSet<Eventos> Evento { get; set; }

        public DbSet<Locais> Local { get; set; }

        public DbSet<Equipamentos> Equipamento { get; set; }

        public DbSet<Reservas> Reserva { get; set; }        


        public static LucyManagerDbContext Create()
        {
            return new LucyManagerDbContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                        
            //Muda o nome da tabela de IdentityUser para Usuarios
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Usuarios")
                .Property(p => p.Id)
                .HasColumnName("UsuarioId");

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Usuarios")
                .Property(p => p.Id)
                .HasColumnName("UsuarioId");
            
            //Muda o nome da tabela de IdentityRole para Roles
            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");

            //Muda o nome da tabela de IdentityUserRole para UserRoles
            modelBuilder.Entity<IdentityUserRole>()
            .ToTable("UserRoles");

            //Muda o nome da tabela de IdentityUserClaim para UserClaims
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaims");

            //Muda o nome da tabela de 
            modelBuilder.Entity<IdentityUserLogin>()
            .ToTable("UserLogins");
        }
    }
}