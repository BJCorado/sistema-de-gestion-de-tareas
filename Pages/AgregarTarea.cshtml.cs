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

        // La propiedad NuevaTarea ya est� enlazada a la vista
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
                // Si hay errores de validaci�n, vuelve a mostrar la p�gina
                return Page();
            }

            // Simula el agregar la tarea en la lista en memoria (sin base de datos)
            await _tareaService.AgregarTareaAsync(NuevaTarea);

            // Redirige a la p�gina de agenda despu�s de agregar la tarea
            return RedirectToPage("Agenda");
        }
    }
}
