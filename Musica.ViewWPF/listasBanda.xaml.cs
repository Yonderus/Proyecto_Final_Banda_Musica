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
    /// <b>Ventana de listas</b><br/>
    /// Sirve para asignar músicos a actuaciones y ver esas asignaciones.
    /// </summary>
    public partial class listasBanda : Window
    {
        private readonly ListasApi _listasApi = new ListasApi();
        private readonly ActuacionesApi _actuacionesApi = new ActuacionesApi();
        private readonly MiembrosApi _miembrosApi = new MiembrosApi();

        public listasBanda()
        {
            InitializeComponent();
            CargarCombos();
            CargarDatos();
        }

        /// <summary>
        /// <b>Cargar combos</b><br/>
        /// Rellena los combos de actuaciones y músicos.
        /// </summary>
        private void CargarCombos()
        {
            var actuaciones = _actuacionesApi.ListarActuaciones();
            cbActuacion.ItemsSource = null;
            cbActuacion.SelectedValuePath = "IdActuacion";
            cbActuacion.ItemsSource = actuaciones;

            var musicos = _miembrosApi.ListarMusicos();
            cbMusico.ItemsSource = null;
            cbMusico.SelectedValuePath = "IdMusico";
            cbMusico.ItemsSource = musicos;
        }

        /// <summary>
        /// <b>Cargar listas</b><br/>
        /// Rellena la tabla con las asignaciones guardadas.
        /// </summary>
        public void CargarDatos()
        {
            dgvListas.ItemsSource = null;
            dgvListas.ItemsSource = _listasApi.ListarListas();
        }

        /// <summary>
        /// <b>Volver</b><br/>
        /// Cierra esta ventana.
        /// </summary>
        private void btbVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// <b>Agregar asignación</b><br/>
        /// Asigna el músico seleccionado a la actuación seleccionada.
        /// </summary>
        private void btbAgregarLista_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbActuacion.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar una actuación.");
                    return;
                }

                if (cbMusico.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un músico.");
                    return;
                }

                var idActuacion = (int)cbActuacion.SelectedValue;
                var idMusico = (int)cbMusico.SelectedValue;

                _listasApi.Agregar(idActuacion, idMusico);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// <b>Eliminar asignación</b><br/>
        /// Borra la asignación seleccionada en la tabla.
        /// </summary>
        private void btbEliminarLista_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var seleccion = dgvListas.SelectedItem as ListaActuacion;
                if (seleccion == null)
                {
                    MessageBox.Show("Debe seleccionar una asignación para eliminar.");
                    return;
                }

                _listasApi.Eliminar(seleccion.IdLista);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// <b>Selección de asignación</b><br/>
        /// Cuando eliges una fila, se seleccionan los combos con los valores de esa fila.
        /// </summary>
        private void dgvListas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seleccion = dgvListas.SelectedItem as ListaActuacion;
            if (seleccion == null)
            {
                cbActuacion.SelectedIndex = -1;
                cbMusico.SelectedIndex = -1;
                return;
            }

            cbActuacion.SelectedValue = seleccion.IdActuacion;
            cbMusico.SelectedValue = seleccion.IdMusico;
        }

        /// <summary>
        /// <b>Cambio de músico</b><br/>
        /// Muestra el instrumento del músico seleccionado.
        /// </summary>
        private void cbMusico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var musico = cbMusico.SelectedItem as Musico;
            if (musico == null)
            {
                txtInstrumentoSeleccionado.Text = string.Empty;
                return;
            }

            var instrumento = musico.Instrumento != null ? musico.Instrumento.Nombre : "(sin instrumento)";
            txtInstrumentoSeleccionado.Text = "Instrumento: " + instrumento;
        }

        /// <summary>
        /// <b>Informe</b><br/>
        /// Abre la ventana del informe de listas.
        /// </summary>
        private void btbInforme_Click(object sender, RoutedEventArgs e)
        {
            var rp = new InformesListas();
            rp.Show();
        }

        /// <summary>
        /// <b>Limpiar</b><br/>
        /// Limpia los combos, el texto de instrumento y la selección de la tabla.
        /// </summary>
        private void btbLimpiar_Click(object sender, RoutedEventArgs e)
        {
            cbActuacion.SelectedIndex = -1;
            cbMusico.SelectedIndex = -1;
            txtInstrumentoSeleccionado.Text = string.Empty;
            dgvListas.UnselectAll();
        }
    }
}
