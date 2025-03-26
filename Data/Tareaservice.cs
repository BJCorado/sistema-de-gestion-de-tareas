using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // Obtener todas las tareas desde la base de datos
        public async Task<List<Tarea>> ObtenerTareasAsync()
        {
            return await _context.Tareas
                .OrderBy(t => t.Fecha)
                .ThenBy(t => t.HoraInicio)
                .ToListAsync();
        }

        // Agregar una tarea a la base de datos
        public async Task AgregarTareaAsync(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
        }

        // Editar una tarea en la base de datos
        public async Task EditarTareaAsync(Tarea tarea)
        {
            // Verifica si la tarea ya existe en la base de datos
            var tareaExistente = await _context.Tareas.FindAsync(tarea.Id);
            if (tareaExistente != null)
            {
                // Actualiza las propiedades de la tarea existente con los nuevos valores
                tareaExistente.Titulo = tarea.Titulo;
                tareaExistente.Descripcion = tarea.Descripcion;
                tareaExistente.Fecha = tarea.Fecha;
                tareaExistente.HoraInicio = tarea.HoraInicio;
                tareaExistente.HoraFin = tarea.HoraFin;
                tareaExistente.Estado = tarea.Estado;

                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            else
            {
                // Si la tarea no existe, podrías lanzar un error o manejarlo de alguna manera
                throw new Exception("La tarea que intentas editar no existe.");
            }
        }


        // Eliminar una tarea de la base de datos
        public async Task EliminarTareaAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
            }
        }

        // Obtener una tarea específica por ID desde la base de datos
        public async Task<Tarea> ObtenerTareaPorIdAsync(int id)
        {
            return await _context.Tareas.FindAsync(id);
        }
    }
}

