using System.ComponentModel.DataAnnotations;
namespace gestion_de_tareas.Data
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public string Contraseña { get; set; }

        // Relación con las tareas (un usuario puede tener muchas tareas)
        public ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();

    }
}
