using gestion_de_tareas.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Text.Json;
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

        // Método para obtener todas las tareas
        public async Task OnGetAsync()
        {
            Tareas = await _tareaService.ObtenerTareasAsync();
        }

        // Método para eliminar una tarea
        public async Task<IActionResult> OnPostEliminarAsync(int id)
        {
            await _tareaService.EliminarTareaAsync(id);
            return RedirectToPage();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Agrega protección contra CSRF
        public async Task<IActionResult> OnPostActualizarEstadoAsync()
        {
            try
            {
                using (var reader = new StreamReader(Request.Body))
                {
                    var body = await reader.ReadToEndAsync();
                    var datos = JsonSerializer.Deserialize<TareaEstadoDto>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (datos == null || datos.Id <= 0 || string.IsNullOrEmpty(datos.Estado))
                    {
                        return BadRequest(new { success = false, message = "Datos inválidos." });
                    }

                    var tarea = await _tareaService.ObtenerTareaPorIdAsync(datos.Id);
                    if (tarea == null)
                    {
                        return NotFound(new { success = false, message = "Tarea no encontrada." });
                    }

                    tarea.Estado = datos.Estado;
                    await _tareaService.EditarTareaAsync(tarea);

                    return new JsonResult(new { success = true, message = "Estado actualizado correctamente." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error interno", error = ex.Message });
            }
        }

        // DTO para recibir los datos
        public class TareaEstadoDto
        {
            public int Id { get; set; }
            public string Estado { get; set; }
        }

    }
}


