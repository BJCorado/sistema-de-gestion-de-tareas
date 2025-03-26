using gestion_de_tareas.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task OnGetAsync()
        {
            // Obtener las tareas de la base de datos de manera asíncrona
            Tareas = await _tareaService.ObtenerTareasAsync();
        }
    }
}

