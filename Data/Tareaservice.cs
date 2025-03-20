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

        // Lista en memoria para simular la base de datos
        private static List<Tarea> _tareasSimuladas = new List<Tarea>();

        public Tareaservice(AgendaDBContext context)
        {
            _context = context;
        }

        // Método asíncrono para obtener tareas desde la base de datos (o de la lista simulada)
        public async Task<List<Tarea>> ObtenerTareasAsync()
        {
            // Si el contexto de la base de datos está disponible, obtenemos de allí
            if (_context != null)
            {
                return await _context.Tareas.OrderBy(t => t.Fecha).ThenBy(t => t.HoraInicio).ToListAsync();
            }
            // Si no hay contexto (simulación), obtenemos de la lista en memoria
            return _tareasSimuladas.OrderBy(t => t.Fecha).ThenBy(t => t.HoraInicio).ToList();
        }

        // Método síncrono para obtener tareas (simulado sin base de datos)
        public List<Tarea> ObtenerTareas()
        {
            if (_context == null)
            {
                // Si no hay base de datos, devolvemos las tareas simuladas en memoria
                return _tareasSimuladas;
            }

            // Si tienes la base de datos, obtén las tareas reales
            return _context.Tareas.OrderBy(t => t.Fecha).ThenBy(t => t.HoraInicio).ToList();
        }

        // Método para agregar tarea (usando la base de datos o en memoria)
        public async Task AgregarTareaAsync(Tarea tarea)
        {
            if (_context != null)
            {
                // Si tienes contexto (base de datos), agrega la tarea a la BD
                _context.Tareas.Add(tarea);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Si no tienes base de datos, agrega la tarea a la lista en memoria
                _tareasSimuladas.Add(tarea);
            }
        }

        // Método para editar tarea (usando la base de datos o en memoria)
        public async Task EditarTareaAsync(Tarea tarea)
        {
            if (_context != null)
            {
                // Si tienes contexto (base de datos), edita la tarea en la BD
                _context.Entry(tarea).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                // Si no tienes base de datos, edita la tarea en memoria
                var tareaExistente = _tareasSimuladas.FirstOrDefault(t => t.Id == tarea.Id);
                if (tareaExistente != null)
                {
                    tareaExistente.Titulo = tarea.Titulo;
                    tareaExistente.Descripcion = tarea.Descripcion;
                    tareaExistente.Fecha = tarea.Fecha;
                    tareaExistente.HoraInicio = tarea.HoraInicio;
                }
            }
        }

        // Método para eliminar tarea (usando la base de datos o en memoria)
        public async Task EliminarTareaAsync(int id)
        {
            if (_context != null)
            {
                // Si tienes contexto (base de datos), elimina la tarea de la BD
                var tarea = await _context.Tareas.FindAsync(id);
                if (tarea != null)
                {
                    _context.Tareas.Remove(tarea);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                // Si no tienes base de datos, elimina la tarea de la lista en memoria
                var tarea = _tareasSimuladas.FirstOrDefault(t => t.Id == id);
                if (tarea != null)
                {
                    _tareasSimuladas.Remove(tarea);
                }
            }
        }

        // Obtener una tarea específica por ID
        public async Task<Tarea> ObtenerTareaPorIdAsync(int id)
        {
            if (_context != null)
            {
                // Si tienes contexto (base de datos), busca la tarea en la BD
                return await _context.Tareas.FindAsync(id);
            }
            else
            {
                // Si no tienes base de datos, busca la tarea en memoria
                return _tareasSimuladas.FirstOrDefault(t => t.Id == id);
            }
        }

        internal Tarea ObtenerTareaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
