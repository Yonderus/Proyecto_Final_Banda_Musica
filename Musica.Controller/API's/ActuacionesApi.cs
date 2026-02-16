using System;
using System.Collections.Generic;
using System.Linq;
using Musica.Model;
using Musica.Model.Repositorios;

namespace Musica.Controller.API_s
{
    /// <summary>
    /// <b>ActuacionesApi</b><br/>
    /// Esta clase sirve para <b>manejar las actuaciones</b> (listarlas, añadirlas, editarlas y eliminarlas).
    /// </summary>
    public class ActuacionesApi
    {
        private ActuacionesRepo repositorio = new ActuacionesRepo();

        /// <summary>
        /// <b>Listar actuaciones</b><br/>
        /// Devuelve todas las actuaciones guardadas.
        /// </summary>
        public List<Actuacion> ListarActuaciones()
        {
            return repositorio.ObtenerTodos();
        }

        /// <summary>
        /// <b>Agregar una actuación</b><br/>
        /// Comprueba que los datos estén bien y guarda una actuación nueva.
        /// </summary>
        public void Agregar(string titulo, DateTime fecha, string lugar, int idTipoActuacion)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new Exception("El título es obligatorio.");

            if (string.IsNullOrWhiteSpace(lugar))
                throw new Exception("El lugar es obligatorio.");

            if (idTipoActuacion <= 0)
                throw new Exception("Debe seleccionar un tipo de actuación válido.");

            if (fecha == default(DateTime))
                throw new Exception("La fecha es obligatoria.");

            if (fecha.Date < DateTime.Today)
                throw new Exception("La fecha no puede ser anterior a hoy.");

            var tituloNorm = titulo.Trim().ToLower();
            var lugarNorm = lugar.Trim().ToLower();
            var fechaNorm = fecha.Date;

            var existe = ListarActuaciones().Any(a =>
                (a.Titulo ?? string.Empty).Trim().ToLower() == tituloNorm &&
                (a.Lugar ?? string.Empty).Trim().ToLower() == lugarNorm &&
                a.Fecha.Date == fechaNorm &&
                a.IdTipoActuacion == idTipoActuacion);

            if (existe)
                throw new Exception("Ya existe una actuación con el mismo título, fecha, lugar y tipo.");

            repositorio.Insertar(new Actuacion
            {
                Titulo = titulo.Trim(),
                Fecha = fechaNorm,
                Lugar = lugar.Trim(),
                IdTipoActuacion = idTipoActuacion
            });
        }

        /// <summary>
        /// <b>Editar una actuación</b><br/>
        /// Cambia los datos de una actuación que ya existe.
        /// </summary>
        public void Editar(int idActuacion, string titulo, DateTime fecha, string lugar, int idTipoActuacion)
        {
            if (idActuacion <= 0)
                throw new Exception("Debe seleccionar una actuación válida.");

            if (string.IsNullOrWhiteSpace(titulo))
                throw new Exception("El título es obligatorio.");

            if (string.IsNullOrWhiteSpace(lugar))
                throw new Exception("El lugar es obligatorio.");

            if (idTipoActuacion <= 0)
                throw new Exception("Debe seleccionar un tipo de actuación válido.");

            if (fecha == default(DateTime))
                throw new Exception("La fecha es obligatoria.");

            if (fecha.Date < DateTime.Today)
                throw new Exception("La fecha no puede ser anterior a hoy.");

            var actuacion = new Actuacion
            {
                IdActuacion = idActuacion,
                Titulo = titulo.Trim(),
                Fecha = fecha,
                Lugar = lugar.Trim(),
                IdTipoActuacion = idTipoActuacion
            };

            repositorio.Editar(actuacion);
        }

        /// <summary>
        /// <b>Eliminar una actuación</b><br/>
        /// Borra una actuación usando su id.
        /// </summary>
        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new Exception("El id debe ser mayor que 0.");

            repositorio.Eliminar(id);
        }
    }
}
