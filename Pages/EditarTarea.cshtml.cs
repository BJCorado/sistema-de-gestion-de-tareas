using gestion_de_tareas.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gestion_de_tareas.Pages
{
    public class EditarTareaModel : PageModel
    {
        private readonly Tareaservice _tareaService;

        [BindProperty]
        public Tarea TareaEditada { get; set; }

        public EditarTareaModel(Tareaservice tareaService)
        {
            _tareaService = tareaService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Obtiene la tarea a editar por ID
            TareaEditada = await _tareaService.ObtenerTareaPorIdAsync(id);

            if (TareaEditada == null)
            {
                return NotFound(); // Si no se encuentra la tarea, se devuelve un 404
            }

            return Page(); // Muestra el formulario para editar la tarea
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Si hay errores de validación, vuelve a mostrar el formulario
            }

            // Llama al servicio para actualizar la tarea
            await _tareaService.EditarTareaAsync(TareaEditada);

            // Redirige a la página de agenda después de editar la tarea
            return RedirectToPage("Agenda");
        }
    }
}
