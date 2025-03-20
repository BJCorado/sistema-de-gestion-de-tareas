using gestion_de_tareas.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gestion_de_tareas.Pages
{
    public class AgendaModel : PageModel
    {
        private readonly Tareaservice _tareaService;

        public List<Tarea> Tareas { get; set; }

        public AgendaModel(Tareaservice tareaService)
        {
            _tareaService = tareaService;
        }

        public void OnGet()
        {
            // Utilizar la simulación de tareas en memoria en lugar de la base de datos
            Tareas = _tareaService.ObtenerTareas();
        }
    }
}
