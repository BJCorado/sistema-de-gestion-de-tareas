using gestion_de_tareas.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gestion_de_tareas.Pages
{
    public class AgregarTareaModel : PageModel
    {
        private readonly Tareaservice _tareaService;

        [BindProperty]
        public Tarea NuevaTarea { get; set; } = new();

        public AgregarTareaModel(Tareaservice tareaService)
        {
            _tareaService = tareaService;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _tareaService.AgregarTarea(NuevaTarea);
            return RedirectToPage("Agenda");
        }
    }
}