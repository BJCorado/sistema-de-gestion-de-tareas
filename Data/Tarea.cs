namespace gestion_de_tareas.Data

{
    public class Tarea
    {
            public int Id { get; set; }
            public string Titulo { get; set; } = "";
            public string Descripcion { get; set; } = "";
        public DateTime Fecha { get; set; }
            public TimeSpan HoraInicio { get; set; }
            public TimeSpan HoraFin { get; set; }
        }

    }
