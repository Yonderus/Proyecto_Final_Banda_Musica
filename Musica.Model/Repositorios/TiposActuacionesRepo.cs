using System.Collections.Generic;
using System.Linq;
using System;

namespace Musica.Model.Repositorios
{
    /// <summary>
    /// <b>TiposActuacionesRepo</b><br/>
    /// Maneja la tabla de <b>tipos de actuación</b> en base de datos.
    /// </summary>
    public class TiposActuacionesRepo
    {
        private readonly BandaEntities _db = new BandaEntities();

        /// <summary>
        /// <b>Obtener tipos</b><br/>
        /// Devuelve todos los tipos de actuación.
        /// </summary>
        public List<TipoActuacion> ObtenerTodos()
        {
            return _db.TipoActuacion.ToList();
        }

        /// <summary>
        /// <b>Insertar tipo</b><br/>
        /// Guarda un tipo nuevo.
        /// </summary>
        public void Insertar(TipoActuacion tipoActuacion)
        {
            _db.TipoActuacion.Add(tipoActuacion);
            _db.SaveChanges();
        }

        /// <summary>
        /// <b>Editar tipo</b><br/>
        /// Cambia el nombre del tipo seleccionado.
        /// </summary>
        public void Editar(TipoActuacion tipoActuacion)
        {
            var existente = _db.TipoActuacion.Find(tipoActuacion.IdTipoActuacion);
            if (existente != null)
            {
                existente.Nombre = tipoActuacion.Nombre;
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// <b>Eliminar tipo</b><br/>
        /// Borra un tipo, pero antes comprueba si tiene actuaciones vinculadas.
        /// </summary>
        public void Eliminar(TipoActuacion tipoActuacion)
        {
            tipoActuacion = _db.TipoActuacion.Find(tipoActuacion.IdTipoActuacion);
            if (tipoActuacion != null)
            {
                var tieneActuaciones = _db.Actuacion.Any(a => a.IdTipoActuacion == tipoActuacion.IdTipoActuacion);
                if (tieneActuaciones)
                    throw new Exception("No se puede eliminar el tipo de actuación porque hay actuaciones vinculadas.");

                _db.TipoActuacion.Remove(tipoActuacion);
                _db.SaveChanges();
            }
        }
    }
}