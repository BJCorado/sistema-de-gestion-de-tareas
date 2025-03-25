using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace gestion_de_tareas.Pages
{
    public class LoginModel : PageModel
    {
        public static List<Usuario> UsuariosRegistrados => RegistroModel.UsuariosRegistrados;

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            var usuario = UsuariosRegistrados.Find(u => u.Username == Username && u.Password == Password);

            if (usuario == null)
            {
                ErrorMessage = "Usuario o contraseña incorrectos.";
                return Page();
            }

            return RedirectToPage("/Index"); // Redirige a la pantalla principal después de iniciar sesión
        }
    }
}