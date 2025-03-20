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
            // Simulaci�n de login sin base de datos
            if (Username == "admin" && Password == "1234")
            {
                return RedirectToPage("/Index"); // Redirigir a la p�gina principal
            }

            ErrorMessage = "Usuario o contrase�a incorrectos.";
            return Page();
        }
    }
}