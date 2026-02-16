using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Musica.Controller.API_s;
using Musica.Model;

namespace Musica.ViewWPF
{
    /// <summary>
    /// <b>Ventana de tipos de actuación</b><br/>
    /// Sirve para ver, añadir y borrar tipos de actuación.
    /// </summary>
    public partial class gestionTipoActuacionesBanda : Window
    {
            private readonly TiposActuacionesApi _tiposActuacionesApi = new TiposActuacionesApi();
        public gestionTipoActuacionesBanda()
        {
            InitializeComponent();
            CargarDatos();
        }

        /// <summary>
        /// <b>Cargar tipos</b><br/>
        /// Rellena la tabla con los tipos de actuación.
        /// </summary>
        public void CargarDatos()
        {
            dgvTipoActuaciones.ItemsSource = null;
            dgvTipoActuaciones.ItemsSource = _tiposActuacionesApi.ListarTiposActuaciones();
        }

        /// <summary>
        /// <b>Volver</b><br/>
        /// Cierra esta ventana.
        /// </summary>
        private void btbGestionTipoActuaciones_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgvTipoActuaciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        /// <summary>
        /// <b>Agregar</b><br/>
        /// Crea un tipo de actuación nuevo con el texto escrito.
        /// </summary>
        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            TipoActuacion tipoactuacion = new TipoActuacion
            {
                Nombre = tb_tipoActuacion.Text,
            };

            _tiposActuacionesApi.Agregar(tipoactuacion.Nombre);
            CargarDatos();
        }

        /// <summary>
        /// <b>Eliminar</b><br/>
        /// Borra el tipo de actuación seleccionado.
        /// </summary>
        private void btbEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var eliminiarTipoActuacion = (TipoActuacion)dgvTipoActuaciones.SelectedItem;

                _tiposActuacionesApi.Eliminar(eliminiarTipoActuacion);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
