using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musica.Model.Repositorios
{
    /// <summary>
    /// <b>ActuacionesRepo</b><br/>
    /// Aquí están las funciones que <b>hablan con la base de datos</b> para las actuaciones.
    /// </summary>
    public class ActuacionesRepo
    {
        private readonly BandaEntities _db = new BandaEntities();

        /// <summary>
        /// <b>Obtener todas las actuaciones</b><br/>
        /// Devuelve las actuaciones tal como están en la tabla.
        /// </summary>
        public List<Actuacion> ObtenerTodos()
        {
            return _db.Actuacion.ToList();
        }

        /// <summary>
        /// <b>Insertar actuación</b><br/>
        /// Guarda una actuación nueva.
        /// </summary>
        public void Insertar(Actuacion actuacion)
        {
            _db.Actuacion.Add(actuacion);
            _db.SaveChanges();
        }

        /// <summary>
        /// <b>Editar actuación</b><br/>
        /// Busca la actuación por id y actualiza sus datos.
        /// </summary>
        public void Editar(Actuacion actuacion)
        {
            var existente = _db.Actuacion.Find(actuacion.IdActuacion);
            if (existente != null)
            {
                existente.Titulo = actuacion.Titulo;
                existente.Fecha = actuacion.Fecha;
                existente.Lugar = actuacion.Lugar;
                existente.IdTipoActuacion = actuacion.IdTipoActuacion;
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// <b>Eliminar actuación</b><br/>
        /// Busca la actuación por id y la borra.
        /// </summary>
        public void Eliminar(int id)
        {
            var actuacion = _db.Actuacion.Find(id);
            if (actuacion != null)
            {
                var tieneListas = _db.ListaActuacion.Any(l => l.IdActuacion == actuacion.IdActuacion);
                if (tieneListas)
                    throw new Exception("No se puede eliminar la actuación porque tiene músicos asignados (listas).");

                _db.Actuacion.Remove(actuacion);
                _db.SaveChanges();
            }
        }
    }
}