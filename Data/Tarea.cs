using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_de_tareas.Data
{
    public class Tarea
    {
        [Key] // Indica que es clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Hace que el Id sea AUTO_INCREMENT
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = "";

        [Required]
        public string Descripcion { get; set; } = "";

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }

        // Propiedad para clasificar las tareas en columnas
        [Required]
        public string Estado { get; set; } = "Por hacer"; // Valor por defecto
    }
}

