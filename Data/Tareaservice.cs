using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_de_tareas.Data
{
    public class Tareaservice
    {
        private readonly AgendaDBContext _context;

        public Tareaservice(AgendaDBContext context)
        {
            _context = context;
        }

        // Método asíncrono para obtener tareas desde la base de datos
        public async Task<List<Tarea>> ObtenerTareasAsync()
        {
            return await _context.Tareas.OrderBy(t => t.Fecha).ThenBy(t => t.HoraInicio).ToListAsync();
        }

        // Método síncrono para obtener tareas (evita errores si aún no usas BD)
        public List<Tarea> ObtenerTareas()
        {
            return new List<Tarea>
            {
                new Tarea { Id = 1, Titulo = "Revisar correos", Descripcion = "Responder correos pendientes", Fecha = DateTime.Today, HoraInicio = new TimeSpan(9, 0, 0) },
                new Tarea { Id = 2, Titulo = "Reunión con equipo", Descripcion = "Revisión de avances del proyecto", Fecha = DateTime.Today, HoraInicio = new TimeSpan(11, 0, 0) },
                new Tarea { Id = 3, Titulo = "Actualizar reporte", Descripcion = "Actualizar informe semanal", Fecha = DateTime.Today, HoraInicio = new TimeSpan(14, 0, 0) }
            };
        }

        // Agregar tarea a la BD
        public async Task AgregarTareaAsync(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
        }

        // Editar tarea existente en la BD
        public async Task EditarTareaAsync(Tarea tarea)
        {
            _context.Entry(tarea).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Eliminar tarea por ID
        public async Task EliminarTareaAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
            }
        }

        // Obtener una tarea específica por ID
        public async Task<Tarea> ObtenerTareaPorIdAsync(int id)
        {
            return await _context.Tareas.FindAsync(id);
        }

        internal Task AgregarTareaAsync(object nuevaTarea)
        {
            throw new NotImplementedException();
        }

        internal Task EditarTareaAsync(object tareaEditada)
        {
            throw new NotImplementedException();
        }

        internal Tarea ObtenerTareaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
