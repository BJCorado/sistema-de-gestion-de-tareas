using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using gestion_de_tareas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace gestion_de_tareas.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AgendaDBContext _context;

        public LoginModel(AgendaDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Nombre == Username && u.Contraseña == Password);

            if (usuario == null)
            {
                ErrorMessage = "Usuario o contraseña incorrectos.";
                return Page();
            }

            // Guardar el usuario en sesión
            HttpContext.Session.SetString("Usuario", usuario.Nombre);

            return RedirectToPage("/Index"); // Redirige a la página principal
        }
    }
}
