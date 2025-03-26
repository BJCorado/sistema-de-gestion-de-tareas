using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace gestion_de_tareas.Data
{
    public class UsuarioService
    {
        private readonly AgendaDBContext _context;

        public UsuarioService(AgendaDBContext context)
        {
            _context = context;
        }

        public void RegistrarUsuario(Usuario usuario)
        {
            usuario.Contraseña = HashPassword(usuario.Contraseña);
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario? IniciarSesion(string nombre, string contraseña)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Nombre == nombre);
            if (usuario != null && VerificarPassword(contraseña, usuario.Contraseña))
            {
                return usuario;
            }
            return null;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerificarPassword(string password, string hashedPassword)
        {
            return HashPassword(password) == hashedPassword;
        }
    }
}

