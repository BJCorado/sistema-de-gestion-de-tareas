using Microsoft.EntityFrameworkCore;

namespace gestion_de_tareas.Data
{
    public class Tareaservice
    {
        private readonly AgendaDBContext _context;

        public Tareaservice(AgendaDBContext context)
        {
            _context = context;
        }

        public async Task<List<Tarea>> ObtenerTareasAsync()
        {
            return await _context.Tareas.OrderBy(t =>t.Fecha).ThenBy(t => t.HoraInicio).ToListAsync();
        }

        public async Task AgregarTareaAsync(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
        }

        public AgendaDBContext Get_context()
        {
            return _context;
        }

        public async Task EditarTareaAsync(Tarea tarea, AgendaDBContext _context)
        {
            _context.Entry(tarea).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;  // Marca la entidad como modificada
            await _context.SaveChangesAsync();  // Guarda los cambios en la base de datos
        }

        public async Task EliminarTareaAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id); // Busca la tarea por ID
            if (tarea != null)  // Verifica si la tarea no es null
            {
                _context.Tareas.Remove(tarea); // Si la tarea existe, la elimina
                await _context.SaveChangesAsync(); // Guarda los cambios
            }
        }

        internal void AgregarTarea(Tarea nuevaTarea)
        {
            throw new NotImplementedException();
        }

        internal Tarea ObtenerTareaPorId(int id)
        {
            throw new NotImplementedException();
        }

        internal void EditarTarea(Tarea tareaEditada)
        {
            throw new NotImplementedException();
        }

        internal List<Tarea> ObtenerTareas()
        {
            throw new NotImplementedException();
        }
    }
}
