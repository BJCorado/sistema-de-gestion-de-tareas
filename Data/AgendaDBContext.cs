using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks; // Asegúrate de tener este using para Task

namespace gestion_de_tareas.Data
{
    // AgendaDBContext hereda de DbContext de Entity Framework Core
    public class AgendaDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        // El constructor recibe las opciones de configuración y las pasa al constructor de la clase base (DbContext)
        public AgendaDBContext(DbContextOptions<AgendaDBContext> options) : base(options) { }

        // DbSet<Tarea> es la propiedad que representa la tabla de tareas en la base de datos
        public Microsoft.EntityFrameworkCore.DbSet<Tarea> Tareas { get; set; }

        // Los métodos SaveChangesAsync y Entry ya existen en DbContext de EF Core,
        // no es necesario definirlos de nuevo, así que puedes eliminarlos.
    }
}

