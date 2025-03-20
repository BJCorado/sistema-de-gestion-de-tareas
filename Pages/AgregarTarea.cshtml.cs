using gestion_de_tareas.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gestion_de_tareas.Pages
{
    public class AgregarTareaModel : PageModel
    {
        private readonly Tareaservice _tareaService;
        private Tarea nuevaTarea;

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
                return Page();
            }

            await _tareaService.AgregarTareaAsync(nuevaTarea);

            return RedirectToPage("Agenda");
        }
    }
}