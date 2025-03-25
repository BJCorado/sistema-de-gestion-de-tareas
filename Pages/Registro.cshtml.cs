using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gestion_de_tareas.Pages
{
    public class RegistroModel : PageModel
    {
        public static List<Usuario> UsuariosRegistrados = new List<Usuario>();

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public void OnPost()
        {
            if (UsuariosRegistrados.Exists(u => u.Username == Username))
            {
                ErrorMessage = "El usuario ya está registrado.";
                return;
            }

            UsuariosRegistrados.Add(new Usuario { Username = Username, Email = Email, Password = Password });
            SuccessMessage = "Registro exitoso. Ahora puedes iniciar sesión.";
        }
    }

    public class Usuario
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
