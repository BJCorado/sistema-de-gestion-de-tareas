using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks; // using para Task

namespace gestion_de_tareas.Data
{
    // AgendaDBContext hereda de DbContext de Entity Framework Core
    public class AgendaDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        // El constructor recibe las opciones de configuración y las pasa al constructor de la clase base (DbContext)
        public AgendaDBContext(DbContextOptions<AgendaDBContext> options) : base(options) { }

        // DbSet<Tarea> es la propiedad que representa la tabla de tareas en la base de datos
        public Microsoft.EntityFrameworkCore.DbSet<Tarea> Tareas { get; set; }

        // DbSet<Tarea> es la propiedad que representa la tabla de Usuario en la base de datos
        public Microsoft.EntityFrameworkCore.DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.Usuario)  // Una tarea pertenece a un usuario
                .WithMany(u => u.Tareas) // Un usuario puede tener muchas tareas
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade); // Si se borra el usuario, se borran sus tareas
        }


        public class Startup
        {
            private readonly IConfiguration _configuration;

            // Inyectar IConfiguration en el constructor de Startup
            public Startup(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public void ConfigureServices(IServiceCollection services)
            {
                // Configurar DbContext para usar MySQL
                services.AddDbContext<AgendaDBContext>(options =>
                    options.UseMySql(_configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(_configuration.GetConnectionString("DefaultConnection"))));
            }
        }
    }

}

