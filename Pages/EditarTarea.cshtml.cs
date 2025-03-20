using gestion_de_tareas.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gestion_de_tareas.Pages
{
    public class EditarTareaModel : PageModel
    {
        private readonly Tareaservice _tareaService;

        [BindProperty]
        public Tarea TareaEditada { get; set; } = new();

        public EditarTareaModel(Tareaservice tareaService)
        {
            _tareaService = tareaService;
        }

        public IActionResult OnGet(int id)
        {
            TareaEditada = _tareaService.ObtenerTareaPorId(id);
            if (TareaEditada == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _tareaService.EditarTarea(TareaEditada);
            return RedirectToPage("Agenda");
        }
    }
}
