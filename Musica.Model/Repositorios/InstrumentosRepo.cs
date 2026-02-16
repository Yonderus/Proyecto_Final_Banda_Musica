using System;
using System.Collections.Generic;
using System.Linq;

namespace Musica.Model.Repositorios
{
    /// <summary>
    /// <b>InstrumentosRepo</b><br/>
    /// Aquí se hacen las operaciones de base de datos para instrumentos.
    /// </summary>
    public class InstrumentosRepo
    {
        private readonly BandaEntities _db = new BandaEntities();

        /// <summary>
        /// <b>Obtener instrumentos</b><br/>
        /// Devuelve todos los instrumentos.
        /// </summary>
        public List<Instrumento> ObtenerTodos()
        {
            return _db.Instrumento.ToList();
        }

        /// <summary>
        /// <b>Insertar instrumento</b><br/>
        /// Guarda un instrumento nuevo.
        /// </summary>
        public void Insertar(Instrumento instrumento)
        {
            _db.Instrumento.Add(instrumento);
            _db.SaveChanges();
        }

        /// <summary>
        /// <b>Editar instrumento</b><br/>
        /// Busca el instrumento por id y cambia su nombre.
        /// </summary>
        public void Editar(Instrumento instrumento)
        {
            var existente = _db.Instrumento.Find(instrumento.IdInstrumento);
            if (existente != null)
            {
                existente.Nombre = instrumento.Nombre;
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// <b>Eliminar instrumento</b><br/>
        /// Borra el instrumento por id.
        /// </summary>
        public void Eliminar(int id)
        {
            var instrumento = _db.Instrumento.Find(id);
            if (instrumento != null)
            {
                _db.Instrumento.Remove(instrumento);
                _db.SaveChanges();
            }
        }
    }
}
