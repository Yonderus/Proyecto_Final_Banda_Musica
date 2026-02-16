using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Musica.Model.Repositorios
{
    /// <summary>
    /// <b>ListasRepo</b><br/>
    /// Guarda y carga las <b>asignaciones</b> de músicos en actuaciones.
    /// </summary>
    public class ListasRepo
    {
        private readonly BandaEntities _db = new BandaEntities();

        /// <summary>
        /// <b>Obtener asignaciones</b><br/>
        /// Devuelve todas las asignaciones y también carga la actuación, el músico y el instrumento.
        /// </summary>
        public List<ListaActuacion> ObtenerTodos()
        {
            return _db.ListaActuacion
                .Include(l => l.Actuacion)
                .Include(l => l.Musico)
                .Include(l => l.Musico.Instrumento)
                .ToList();
        }

        /// <summary>
        /// <b>Insertar asignación</b><br/>
        /// Guarda una nueva asignación.
        /// </summary>
        public void Insertar(ListaActuacion lista)
        {
            _db.ListaActuacion.Add(lista);
            _db.SaveChanges();
        }

        /// <summary>
        /// <b>Eliminar asignación</b><br/>
        /// Borra una asignación usando su id.
        /// </summary>
        public void Eliminar(int idLista)
        {
            var lista = _db.ListaActuacion.Find(idLista);
            if (lista != null)
            {
                _db.ListaActuacion.Remove(lista);
                _db.SaveChanges();
            }
        }
    }
}