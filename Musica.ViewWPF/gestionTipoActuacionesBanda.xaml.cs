using System;
using System.Windows;
using System.Windows.Controls;
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
            var seleccionado = dgvTipoActuaciones.SelectedItem as TipoActuacion;
            if (seleccionado == null)
            {
                tb_tipoActuacion.Text = string.Empty;
                return;
            }

            tb_tipoActuacion.Text = seleccionado.Nombre ?? string.Empty;
        }

        /// <summary>
        /// <b>Agregar</b><br/>
        /// Crea un tipo de actuación nuevo con el texto escrito.
        /// </summary>
        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _tiposActuacionesApi.Agregar(tb_tipoActuacion.Text);
                tb_tipoActuacion.Text = string.Empty;
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// <b>Editar</b><br/>
        /// Edita el tipo de actuación seleccionado usando el texto de la caja.
        /// </summary>
        private void btbEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var seleccionado = dgvTipoActuaciones.SelectedItem as TipoActuacion;
                if (seleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de actuación para editar.");
                    return;
                }

                seleccionado.Nombre = tb_tipoActuacion.Text;

                _tiposActuacionesApi.Editar(seleccionado);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// <b>Eliminar</b><br/>
        /// Borra el tipo de actuación seleccionado.
        /// </summary>
        private void btbEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var eliminiarTipoActuacion = dgvTipoActuaciones.SelectedItem as TipoActuacion;
                if (eliminiarTipoActuacion == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de actuación para eliminar.");
                    return;
                }

                _tiposActuacionesApi.Eliminar(eliminiarTipoActuacion);
                tb_tipoActuacion.Text = string.Empty;
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
