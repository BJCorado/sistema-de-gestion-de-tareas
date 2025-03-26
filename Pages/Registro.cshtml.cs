using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using gestion_de_tareas.Data;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_de_tareas.Pages
{
    public class RegistroModel : PageModel
    {
        private readonly AgendaDBContext _context;

        public RegistroModel(AgendaDBContext context)
        {
            _context = context;
        }

        public static List<Usuario> UsuariosRegistrados { get; internal set; }
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.Usuarios.Any(u => u.Nombre == Username))
            {
                ErrorMessage = "El usuario ya está registrado.";
                return Page();
            }

            var nuevoUsuario = new Usuario
            {
                Nombre = Username,
                Correo = Email,
                Contraseña = Password
            };

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

            SuccessMessage = "Registro exitoso. Ahora puedes iniciar sesión.";
            return Page();
        }
    }
}
