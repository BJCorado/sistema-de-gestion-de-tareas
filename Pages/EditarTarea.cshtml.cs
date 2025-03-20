using gestion_de_tareas.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gestion_de_tareas.Pages
{
    public class EditarTareaModel : PageModel
    {
        private readonly Tareaservice _tareaService;
        private Tarea tareaEditada;

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _tareaService.EditarTareaAsync(tareaEditada);

            return RedirectToPage("Agenda");
        }
    }
}
