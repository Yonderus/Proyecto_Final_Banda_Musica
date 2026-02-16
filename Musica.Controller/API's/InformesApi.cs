using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Musica.Model;
using Musica.Model.Informes;

namespace Musica.Controller.API_s
{
    /// <summary>
    /// <b>InformesApi</b><br/>
    /// Esta clase prepara los datos para los <b>informes</b> (músicos, actuaciones y listas).
    /// </summary>
    public class InformesApi
    {
        /// <summary>
        /// <b>Datos de músicos para informe</b><br/>
        /// Lee músicos de la base de datos y los mete en un DataSet.
        /// </summary>
        public BandaMusicaDS GetMusicosDataSet()
        {
            using (var db = new BandaEntities())
            {
                var ds = new BandaMusicaDS();
                var tabla = ds.Musico;

                foreach (var musico in db.Musico.ToList())
                {
                    tabla.AddMusicoRow(
                        musico.Nombre,
                        musico.Apellidos,
                        musico.Telefono,
                        musico.Email,
                        musico.IdMusico.ToString()
                    );
                }

                return ds;
            }
        }

        /// <summary>
        /// <b>Datos de actuaciones para informe</b><br/>
        /// Lee actuaciones con su tipo y las mete en un DataSet.
        /// </summary>
        public BandaMusicaDS GetActuacionesDataSet()
        {
            using (var db = new BandaEntities())
            {
                var ds = new BandaMusicaDS();
                var tabla = ds.Actuacion;

                var lista = db.Actuacion.Include("TipoActuacion").ToList();

                foreach (var actuacion in lista)
                {
                    tabla.AddActuacionRow(
                        actuacion.Titulo,
                        actuacion.Fecha.ToString("yyyy-MM-dd"),
                        actuacion.Lugar,
                        actuacion.TipoActuacion?.Nombre
                    );
                }

                return ds;
            }
        }

        /// <summary>
        /// <b>Datos de listas (asignaciones) para informe</b><br/>
        /// Lee listas con actuación y músico y las mete en un DataSet.
        /// </summary>
        public BandaMusicaDS GetListasActuacionesDataSet()
        {
            using (var db = new BandaEntities())
            {
                var ds = new BandaMusicaDS();
                var tabla = ds.ListaActuacion;

                var lista = db.ListaActuacion.Include("Actuacion").Include("Musico").ToList();

                foreach (var listasActuacion in lista)
                {
                    tabla.AddListaActuacionRow(
                        listasActuacion.Actuacion?.Titulo,
                        listasActuacion.Musico.Nombre,
                        listasActuacion.Musico.Apellidos
                    );
                }

                return ds;
            }
        }
    }
}
