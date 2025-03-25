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
        [HttpPost]
        public IActionResult OnPostActualizarEstadoTarea(int id, string estado)
        {
            var tarea = _tareaService.ObtenerTareas().FirstOrDefault(t => t.Id == id);
            if (tarea == null)
            {
                return NotFound(new { mensaje = "Tarea no encontrada" });
            }

            tarea.Estado = estado;
            _tareaService.ActualizarTarea(tarea);

            return new JsonResult(new { mensaje = "Estado actualizado con éxito" });
        }


        public void OnGet()
        {
            // Utilizar la simulación de tareas en memoria en lugar de la base de datos
            Tareas = _tareaService.ObtenerTareas();
        }
    }
}
