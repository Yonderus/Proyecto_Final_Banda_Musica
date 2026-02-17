using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// <b>Ventana de actuaciones</b><br/>
    /// Sirve para ver, añadir, editar y eliminar actuaciones.
    /// </summary>
    public partial class actuaciones : Window
    {
        private readonly ActuacionesApi _ActuacionesApi = new ActuacionesApi();
        private readonly TiposActuacionesApi _tiposActuacionesApi = new TiposActuacionesApi();

        public actuaciones()
        {
            InitializeComponent();
            CargarTiposActuacion();
            CargarDatos();
        }

        /// <summary>
        /// <b>Cargar actuaciones</b><br/>
        /// Rellena la tabla con las actuaciones guardadas.
        /// </summary>
        public void CargarDatos()
        {
            dgvActuaciones.ItemsSource = null;
            dgvActuaciones.ItemsSource = _ActuacionesApi.ListarActuaciones();
        }

        /// <summary>
        /// <b>Cargar tipos</b><br/>
        /// Rellena el combo con los tipos de actuación.
        /// </summary>
        private void CargarTiposActuacion()
        {
            var tipos = _tiposActuacionesApi.ListarTiposActuaciones();

            cbTipoActuacion.ItemsSource = null;
            cbTipoActuacion.DisplayMemberPath = "Nombre";
            cbTipoActuacion.SelectedValuePath = "IdTipoActuacion";
            cbTipoActuacion.ItemsSource = tipos;
        }

        /// <summary>
        /// <b>Ir a gestión de tipos</b><br/>
        /// Abre la ventana donde se pueden manejar los tipos de actuación.
        /// </summary>
        private void btbGestionTipoActuaciones_Click(object sender, RoutedEventArgs e)
        {
            var wpf = new gestionTipoActuacionesBanda();
            wpf.Show();
        }

        /// <summary>
        /// <b>Volver</b><br/>
        /// Cierra la ventana actual.
        /// </summary>
        private void btbVolverPaginaAnterior_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// <b>Agregar</b><br/>
        /// Crea una actuación con los datos escritos y la guarda.
        /// </summary>
        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var tipoActuacionSeleccionada = cbTipoActuacion.SelectedItem as TipoActuacion;
                if (tipoActuacionSeleccionada == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de actuación.");
                    return;
                }

                Actuacion actuacion = new Actuacion
                {
                    Titulo = tb_TituloActuacion.Text,
                    Fecha = DateTime.Parse(dtp_FechaActuacion.Text),
                    TipoActuacion = tipoActuacionSeleccionada,
                    Lugar = tb_LugarActuacion.Text,
                    IdTipoActuacion = tipoActuacionSeleccionada.IdTipoActuacion
                };

                _ActuacionesApi.Agregar(actuacion.Titulo, actuacion.Fecha, actuacion.Lugar, actuacion.IdTipoActuacion);

                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// <b>Eliminar</b><br/>
        /// Borra la actuación seleccionada en la tabla.
        /// </summary>
        private void btbEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var actuacionEliminar = dgvActuaciones.SelectedItem as Actuacion;
                if (actuacionEliminar == null)
                {
                    MessageBox.Show("Debe seleccionar una actuación para eliminar.");
                    return;
                }

                _ActuacionesApi.Eliminar(actuacionEliminar.IdActuacion);

                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// <b>Selección de tabla</b><br/>
        /// Cuando seleccionas una actuación, pone sus datos en los campos.
        /// </summary>
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seleccionada = dgvActuaciones.SelectedItem as Actuacion;
            if (seleccionada == null)
                return;

            tb_TituloActuacion.Text = seleccionada.Titulo;
            dtp_FechaActuacion.SelectedDate = seleccionada.Fecha;
            tb_LugarActuacion.Text = seleccionada.Lugar;

            cbTipoActuacion.SelectedValue = seleccionada.IdTipoActuacion;
        }

        private void cbTipoActuacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        /// <summary>
        /// <b>Editar</b><br/>
        /// Guarda cambios en la actuación seleccionada.
        /// </summary>
        private void btbEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var seleccionada = dgvActuaciones.SelectedItem as Actuacion;
                if (seleccionada == null)
                {
                    MessageBox.Show("Debe seleccionar una actuación para editar.");
                    return;
                }

                var tipoActuacionSeleccionada = cbTipoActuacion.SelectedItem as TipoActuacion;
                if (tipoActuacionSeleccionada == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de actuación.");
                    return;
                }

                if (!dtp_FechaActuacion.SelectedDate.HasValue)
                {
                    MessageBox.Show("Debe seleccionar una fecha.");
                    return;
                }

                _ActuacionesApi.Editar(
                    seleccionada.IdActuacion,
                    tb_TituloActuacion.Text,
                    dtp_FechaActuacion.SelectedDate.Value,
                    tb_LugarActuacion.Text,
                    tipoActuacionSeleccionada.IdTipoActuacion);

                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// <b>Informe</b><br/>
        /// Abre la ventana del informe de actuaciones.
        /// </summary>
        private void btbInforme_Click(object sender, RoutedEventArgs e)
        {
            var rp = new InformesActuaciones();
            rp.Show();
        }

        /// <summary>
        /// <b>Limpiar campos</b><br/>
        /// Limpia los campos del formulario.
        /// </summary>
        private void btbLimpiar_Click(object sender, RoutedEventArgs e)
        {
            // Limpia los campos del formulario
            cbTipoActuacion.SelectedIndex = -1;
            tb_TituloActuacion.Text = string.Empty;
            dtp_FechaActuacion.SelectedDate = null;
            tb_LugarActuacion.Text = string.Empty;
            dgvActuaciones.UnselectAll();
        }
    }
}
