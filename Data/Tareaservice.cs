using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_de_tareas.Data
{
    public class Tareaservice
    {
        // Lista en memoria para simular la base de datos
        private static List<Tarea> _tareasSimuladas = new List<Tarea>
        {
            new Tarea { Id = 1, Titulo = "Revisar correos", Descripcion = "Responder correos pendientes", Fecha = DateTime.Today, HoraInicio = new TimeSpan(9, 0, 0) },
            new Tarea { Id = 2, Titulo = "Reunión con equipo", Descripcion = "Revisión de avances del proyecto", Fecha = DateTime.Today, HoraInicio = new TimeSpan(11, 0, 0) },
            new Tarea { Id = 3, Titulo = "Actualizar reporte", Descripcion = "Actualizar informe semanal", Fecha = DateTime.Today, HoraInicio = new TimeSpan(14, 0, 0) }
        };

        // Obtener todas las tareas (solo desde la lista simulada)
        public Task<List<Tarea>> ObtenerTareasAsync()
        {
            // Retorna las tareas simuladas ordenadas por fecha y hora de inicio
            return Task.FromResult(_tareasSimuladas.OrderBy(t => t.Fecha).ThenBy(t => t.HoraInicio).ToList());
        }

        // Obtener todas las tareas (solo desde la lista simulada)
        public List<Tarea> ObtenerTareas()
        {
            return _tareasSimuladas.OrderBy(t => t.Fecha).ThenBy(t => t.HoraInicio).ToList();
        }

        // Agregar tarea a la lista simulada
        public Task AgregarTareaAsync(Tarea tarea)
        {
            // Asigna un ID automáticamente (en caso de que se agregue una nueva tarea sin ID)
            tarea.Id = _tareasSimuladas.Max(t => t.Id) + 1;
            _tareasSimuladas.Add(tarea);
            return Task.CompletedTask;
        }

        // Editar tarea en la lista simulada
        public Task EditarTareaAsync(Tarea tarea)
        {
            var tareaExistente = _tareasSimuladas.FirstOrDefault(t => t.Id == tarea.Id);
            if (tareaExistente != null)
            {
                tareaExistente.Titulo = tarea.Titulo;
                tareaExistente.Descripcion = tarea.Descripcion;
                tareaExistente.Fecha = tarea.Fecha;
                tareaExistente.HoraInicio = tarea.HoraInicio;
            }
            return Task.CompletedTask;
        }

        // Eliminar tarea de la lista simulada
        public Task EliminarTareaAsync(int id)
        {
            var tarea = _tareasSimuladas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                _tareasSimuladas.Remove(tarea);
            }
            return Task.CompletedTask;
        }
        public void ActualizarTarea(Tarea tareaActualizada)
        {
            var tarea = _tareasSimuladas.FirstOrDefault(t => t.Id == tareaActualizada.Id);
            if (tarea != null)
            {
                tarea.Estado = tareaActualizada.Estado;
            }
        }


        // Obtener una tarea específica por ID desde la lista simulada
        public Task<Tarea> ObtenerTareaPorIdAsync(int id)
        {
            var tarea = _tareasSimuladas.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(tarea);
        }
    }
}

