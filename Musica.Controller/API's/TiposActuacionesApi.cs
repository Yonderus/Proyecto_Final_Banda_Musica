using System;
using System.Collections.Generic;
using System.Linq;
using Musica.Model;
using Musica.Model.Repositorios;

namespace Musica.Controller.API_s
{
    /// <summary>
    /// <b>TiposActuacionesApi</b><br/>
    /// Sirve para <b>gestionar los tipos de actuación</b> (listar, añadir, editar y eliminar).
    /// </summary>
    public class TiposActuacionesApi
    {
        private TiposActuacionesRepo repositorio = new TiposActuacionesRepo();

        /// <summary>
        /// <b>Listar tipos</b><br/>
        /// Devuelve todos los tipos de actuación.
        /// </summary>
        public List<TipoActuacion> ListarTiposActuaciones()
        {
            return repositorio.ObtenerTodos();
        }

        /// <summary>
        /// <b>Agregar tipo</b><br/>
        /// Guarda un tipo nuevo si el nombre no está vacío y no está repetido.
        /// </summary>
        public void Agregar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre es obligatorio.");

            var nombreNorm = nombre.Trim().ToLower();
            if (ListarTiposActuaciones().Any(t => (t.Nombre ?? string.Empty).Trim().ToLower() == nombreNorm))
                throw new Exception("Ya existe un tipo de actuación con ese nombre.");

            repositorio.Insertar(new TipoActuacion { Nombre = nombre.Trim() });
        }

        /// <summary>
        /// <b>Editar tipo</b><br/>
        /// Cambia el nombre de un tipo de actuación.
        /// </summary>
        public void Editar(TipoActuacion tipoActuacion)
        {
            if (tipoActuacion == null)
                throw new Exception("Debe seleccionar un tipo de actuación válido.");

            if (string.IsNullOrWhiteSpace(tipoActuacion.Nombre))
                throw new Exception("El nombre es obligatorio.");

            var nombreNorm = tipoActuacion.Nombre.Trim().ToLower();

            if (ListarTiposActuaciones().Any(t =>
                t.IdTipoActuacion != tipoActuacion.IdTipoActuacion &&
                (t.Nombre ?? string.Empty).Trim().ToLower() == nombreNorm))
            {
                throw new Exception("Ya existe un tipo de actuación con ese nombre.");
            }

            repositorio.Editar(tipoActuacion);
        }

        /// <summary>
        /// <b>Eliminar tipo</b><br/>
        /// Borra un tipo de actuación (si se puede).
        /// </summary>
        public void Eliminar(TipoActuacion tipoActuacion)
        {
            repositorio.Eliminar(tipoActuacion);
        }
    }
}