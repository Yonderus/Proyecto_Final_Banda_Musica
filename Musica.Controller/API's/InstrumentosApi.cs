using System;
using System.Collections.Generic;
using System.Linq;
using Musica.Model;
using Musica.Model.Repositorios;

namespace Musica.Controller.API_s
{
    /// <summary>
    /// <b>InstrumentosApi</b><br/>
    /// Esta clase se usa para <b>gestionar instrumentos</b> (ver, añadir, editar y eliminar).
    /// </summary>
    public class InstrumentosApi
    {
        private InstrumentosRepo repositorio = new InstrumentosRepo();

        /// <summary>
        /// <b>Listar instrumentos</b><br/>
        /// Devuelve todos los instrumentos guardados.
        /// </summary>
        public List<Instrumento> ListarInstrumentos()
        {
            return repositorio.ObtenerTodos();
        }

        /// <summary>
        /// <b>Agregar instrumento</b><br/>
        /// Comprueba el nombre y lo guarda si no existe ya.
        /// </summary>
        public void Agregar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre es obligatorio.");

            var nombreNorm = nombre.Trim().ToLower();   

            var existe = ListarInstrumentos().Any(i => (i.Nombre ?? string.Empty).Trim().ToLower() == nombreNorm);
            if (existe)
                throw new Exception("Ya existe un instrumento con ese nombre.");

            var instrumento = new Instrumento { Nombre = nombre.Trim() };
            repositorio.Insertar(instrumento);
        }

        /// <summary>
        /// <b>Editar instrumento</b><br/>
        /// Cambia el nombre del instrumento seleccionado.
        /// </summary>
        public void Editar(int idInstrumento, string nombre)
        {
            if (idInstrumento <= 0)
                throw new Exception("Debe seleccionar un instrumento válido.");

            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre es obligatorio.");

            var nombreNorm = nombre.Trim().ToLower();

            var existe = ListarInstrumentos().Any(i =>
                i.IdInstrumento != idInstrumento &&
                (i.Nombre ?? string.Empty).Trim().ToLower() == nombreNorm);

            if (existe)
                throw new Exception("Ya existe un instrumento con ese nombre.");

            repositorio.Editar(new Instrumento { IdInstrumento = idInstrumento, Nombre = nombre.Trim() });
        }

        /// <summary>
        /// <b>Eliminar instrumento</b><br/>
        /// Borra el instrumento usando su id.
        /// </summary>
        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new Exception("El id debe ser mayor que 0.");

            repositorio.Eliminar(id);
        }
    }
}
