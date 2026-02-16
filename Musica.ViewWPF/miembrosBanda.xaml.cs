using System;
using System.Windows;
using System.Windows.Controls;
using Musica.Controller.API_s;
using Musica.Model;

namespace Musica.ViewWPF
{
    /// <summary>
    /// <b>Ventana de miembros</b><br/>
    /// Sirve para gestionar músicos: verlos, añadirlos, editarlos y eliminarlos.
    /// </summary>
    public partial class miembrosBanda : Window
    {
        private readonly MiembrosApi _miembrosApi = new MiembrosApi();
        private readonly InstrumentosApi _instrumentosApi = new InstrumentosApi();

        public miembrosBanda()
        {
            InitializeComponent();
            CargarInstrumentos();
            CargarDatos();
        }

        /// <summary>
        /// <b>Cargar instrumentos</b><br/>
        /// Rellena el combo con los instrumentos.
        /// </summary>
        private void CargarInstrumentos()
        {
            var instrumentos = _instrumentosApi.ListarInstrumentos();

            cbInstrumento.ItemsSource = null;
            cbInstrumento.DisplayMemberPath = "Nombre";
            cbInstrumento.SelectedValuePath = "IdInstrumento";
            cbInstrumento.ItemsSource = instrumentos;
        }

        /// <summary>
        /// <b>Cargar músicos</b><br/>
        /// Rellena la tabla con los músicos guardados.
        /// </summary>
        public void CargarDatos()
        {
            dgvMiembros.ItemsSource = null;
            dgvMiembros.ItemsSource = _miembrosApi.ListarMusicos();
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
        /// <b>Agregar músico</b><br/>
        /// Lee los datos de los campos y crea un músico nuevo.
        /// </summary>
        private void btbAgregarMiembro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var instrumento = cbInstrumento.SelectedItem;
                if (instrumento == null)
                {
                    MessageBox.Show("Debe seleccionar un instrumento.");
                    return;
                }

                var idInstrumento = (int)cbInstrumento.SelectedValue;

                _miembrosApi.Agregar(
                    tbNombre.Text,
                    tbApellidos.Text,
                    tbTelefono.Text,
                    tbEmail.Text,
                    idInstrumento);

                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// <b>Editar músico</b><br/>
        /// Actualiza el músico seleccionado con los valores de los campos.
        /// </summary>
        private void btbEditarMiembro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var seleccionado = dgvMiembros.SelectedItem as Musico;
                if (seleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un músico para editar.");
                    return;
                }

                if (cbInstrumento.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un instrumento.");
                    return;
                }

                var idInstrumento = (int)cbInstrumento.SelectedValue;

                _miembrosApi.Editar(
                    seleccionado.IdMusico,
                    tbNombre.Text,
                    tbApellidos.Text,
                    tbTelefono.Text,
                    tbEmail.Text,
                    idInstrumento);

                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// <b>Eliminar músico</b><br/>
        /// Borra el músico seleccionado de la tabla.
        /// </summary>
        private void btbEliminarMiembro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var seleccionado = dgvMiembros.SelectedItem as Musico;
                if (seleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un músico para eliminar.");
                    return;
                }

                _miembrosApi.Eliminar(seleccionado.IdMusico);

                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// <b>Selección de músico</b><br/>
        /// Cuando eliges un músico, aparece su información en los campos.
        /// </summary>
        private void dgvMiembros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seleccionado = dgvMiembros.SelectedItem as Musico;
            if (seleccionado == null)
            {
                tbNombre.Text = string.Empty;
                tbApellidos.Text = string.Empty;
                tbTelefono.Text = string.Empty;
                tbEmail.Text = string.Empty;
                cbInstrumento.SelectedIndex = -1;
                return;
            }

            tbNombre.Text = seleccionado.Nombre ?? string.Empty;
            tbApellidos.Text = seleccionado.Apellidos ?? string.Empty;
            tbTelefono.Text = seleccionado.Telefono ?? string.Empty;
            tbEmail.Text = seleccionado.Email ?? string.Empty;

            cbInstrumento.SelectedValue = seleccionado.IdInstrumento;
        }

        private void cbInstrumento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        /// <summary>
        /// <b>Informe</b><br/>
        /// Abre la ventana del informe de músicos.
        /// </summary>
        private void btbInforme_Click(object sender, RoutedEventArgs e)
        {
            var rp = new InformesMusico();
            rp.Show();
        }
    }
}
