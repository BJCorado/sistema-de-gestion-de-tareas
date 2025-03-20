using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gestion_de_tareas.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            // Simulación de login sin base de datos
            if (Username == "admin" && Password == "1234")
            {
                return RedirectToPage("/Index"); // Redirigir a la página principal
            }

            ErrorMessage = "Usuario o contraseña incorrectos.";
            return Page();
        }
    }
}