using gestion_de_tareas.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestion_de_tareas.Pages
{
    public class AgregarTareaModel : PageModel
    {
        private readonly Tareaservice _tareaService;

        // La propiedad NuevaTarea ya está enlazada a la vista
        [BindProperty]
        public Tarea NuevaTarea { get; set; } = new();

        public AgregarTareaModel(Tareaservice tareaService)
        {
            _tareaService = tareaService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Si hay errores de validación, vuelve a mostrar la página
                return Page();
            }

            // Simula el agregar la tarea en la lista en memoria (sin base de datos)
            await _tareaService.AgregarTareaAsync(NuevaTarea);

            // Redirige a la página de agenda después de agregar la tarea
            return RedirectToPage("Agenda");
        }
    }
}
