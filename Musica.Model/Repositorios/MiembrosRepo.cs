using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Musica.Model.Repositorios
{
    /// <summary>
    /// <b>MiembrosRepo</b><br/>
    /// Aquí están las funciones que leen y guardan <b>músicos</b> en la base de datos.
    /// </summary>
    public class MiembrosRepo
    {
        private readonly BandaEntities _db = new BandaEntities();

        /// <summary>
        /// <b>Obtener todos</b><br/>
        /// Devuelve la lista de músicos y también carga su instrumento.
        /// </summary>
        public List<Musico> ObtenerTodos()
        {
            return _db.Musico.Include(m => m.Instrumento).ToList();
        }

        /// <summary>
        /// <b>Insertar</b><br/>
        /// Guarda un músico nuevo en la base de datos.
        /// </summary>
        public void Insertar(Musico musico)
        {
            _db.Musico.Add(musico);
            _db.SaveChanges();
        }

        /// <summary>
        /// <b>Editar</b><br/>
        /// Busca el músico por id y actualiza sus datos.
        /// </summary>
        public void Editar(Musico musico)
        {
            var existente = _db.Musico.Find(musico.IdMusico);
            if (existente != null)
            {
                existente.Nombre = musico.Nombre;
                existente.Telefono = musico.Telefono;
                existente.Email = musico.Email;
                existente.IdInstrumento = musico.IdInstrumento;

                _db.SaveChanges();
            }
        }

        /// <summary>
        /// <b>Eliminar</b><br/>
        /// Busca el músico por id y lo borra.
        /// </summary>
        public void Eliminar(int id)
        {
            var musico = _db.Musico.Find(id);
            if (musico != null)
            {
                _db.Musico.Remove(musico);
                _db.SaveChanges();
            }
        }
    }
}
