using System;
using System.Collections.Generic;
using System.Linq;
using Musica.Model;
using Musica.Model.Repositorios;

namespace Musica.Controller.API_s
{
    /// <summary>
    /// <b>ListasApi</b><br/>
    /// Sirve para <b>asignar músicos a actuaciones</b> y para ver/borrar esas asignaciones.
    /// </summary>
    public class ListasApi
    {
        private ListasRepo repositorio = new ListasRepo();

        /// <summary>
        /// <b>Listar asignaciones</b><br/>
        /// Devuelve la lista de músicos asignados a actuaciones.
        /// </summary>
        public List<ListaActuacion> ListarListas()
        {
            return repositorio.ObtenerTodos();
        }

        /// <summary>
        /// <b>Agregar asignación</b><br/>
        /// Crea una relación entre una actuación y un músico (si no existe ya).
        /// </summary>
        public void Agregar(int idActuacion, int idMusico)
        {
            if (idActuacion <= 0)
                throw new Exception("Debe seleccionar una actuación válida.");

            if (idMusico <= 0)
                throw new Exception("Debe seleccionar un músico válido.");

            var existe = ListarListas().Any(l =>
                l.IdActuacion == idActuacion &&
                l.IdMusico == idMusico);

            if (existe)
                throw new Exception("Ese músico ya está asignado a esa actuación.");

            var lista = new ListaActuacion
            {
                IdActuacion = idActuacion,
                IdMusico = idMusico
            };

            repositorio.Insertar(lista);
        }

        /// <summary>
        /// <b>Eliminar asignación</b><br/>
        /// Borra una asignación usando el id de la lista.
        /// </summary>
        public void Eliminar(int idLista)
        {
            if (idLista <= 0)
                throw new Exception("Debe seleccionar una asignación válida.");

            repositorio.Eliminar(idLista);
        }
    }
}