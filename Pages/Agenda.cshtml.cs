using gestion_de_tareas.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gestion_de_tareas.Pages
{
    public class AgendaModel : PageModel
    {
        private readonly Tareaservice _tareaService;

        public List<Tarea> Tareas { get; set; } = new();

        public AgendaModel(Tareaservice tareaService)
        {
            _tareaService = tareaService;
        }

        public void OnGet()
        {
            Tareas = _tareaService.ObtenerTareas();
        }
    }
}