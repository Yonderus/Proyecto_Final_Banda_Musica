using System;
using System.Windows;
using System.Windows.Controls;
using Musica.Controller.API_s;
using Musica.Model;

namespace Musica.ViewWPF
{
    /// <summary>
    /// <b>Ventana de instrumentos</b><br/>
    /// Sirve para ver, añadir, editar y eliminar instrumentos.
    /// </summary>
    public partial class instrumentosBanda : Window
    {
        private readonly InstrumentosApi _instrumentosApi = new InstrumentosApi();

        public instrumentosBanda()
        {
            InitializeComponent();
            CargarDatos();
        }

        /// <summary>
        /// <b>Cargar instrumentos</b><br/>
        /// Rellena la tabla con los instrumentos.
        /// </summary>
        public void CargarDatos()
        {
            dgvInstrumentos.ItemsSource = null;
            dgvInstrumentos.ItemsSource = _instrumentosApi.ListarInstrumentos();
        }

        /// <summary>
        /// <b>Volver</b><br/>
        /// Cierra esta ventana.
        /// </summary>
        private void btbVolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// <b>Selección de instrumento</b><br/>
        /// Cuando seleccionas uno, su nombre aparece en la caja de texto.
        /// </summary>
        private void dgvInstrumentos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seleccionado = dgvInstrumentos.SelectedItem as Instrumento;
            if (seleccionado == null)
            {
                tbNombreInstrumento.Text = string.Empty;
                return;
            }

            tbNombreInstrumento.Text = seleccionado.Nombre ?? string.Empty;
        }

        /// <summary>
        /// <b>Agregar</b><br/>
        /// Guarda un instrumento nuevo con el nombre escrito.
        /// </summary>
        private void btbAgregarInstrumento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _instrumentosApi.Agregar(tbNombreInstrumento.Text);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// <b>Editar</b><br/>
        /// Actualiza el instrumento seleccionado.
        /// </summary>
        private void btbEditarInstrumento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var seleccionado = dgvInstrumentos.SelectedItem as Instrumento;
                if (seleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un instrumento para editar.");
                    return;
                }

                _instrumentosApi.Editar(seleccionado.IdInstrumento, tbNombreInstrumento.Text);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// <b>Eliminar</b><br/>
        /// Borra el instrumento seleccionado.
        /// </summary>
        private void btbEliminarInstrumento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var seleccionado = dgvInstrumentos.SelectedItem as Instrumento;
                if (seleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un instrumento para eliminar.");
                    return;
                }

                _instrumentosApi.Eliminar(seleccionado.IdInstrumento);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
