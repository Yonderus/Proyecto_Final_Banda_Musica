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

namespace Musica.ViewWPF
{
    /// <summary>
    /// <b>Ventana del menú</b><br/>
    /// Aquí se abren las distintas pantallas de la aplicación.
    /// </summary>
    public partial class menuBanda : Window
    {
        public menuBanda()
        {
            InitializeComponent();
        }

        /// <summary>
        /// <b>Botón Actuaciones</b><br/>
        /// Abre la ventana de actuaciones.
        /// </summary>
        private void btbActuaciones_Click(object sender, RoutedEventArgs e)
        {
            var wpf = new actuaciones();
            wpf.Show();
        }

        /// <summary>
        /// <b>Botón Miembros</b><br/>
        /// Abre la ventana de miembros.
        /// </summary>
        private void btbMiembrosBanda_Click(object sender, RoutedEventArgs e)
        {
            var wpf = new miembrosBanda();
            wpf.Show();
        }

        /// <summary>
        /// <b>Botón Instrumentos</b><br/>
        /// Abre la ventana de instrumentos.
        /// </summary>
        private void btbInstrumentos_Click(object sender, RoutedEventArgs e)
        {
            var wpf = new instrumentosBanda();
            wpf.Show();
        }

        /// <summary>
        /// <b>Botón Listas</b><br/>
        /// Abre la ventana de listas (asignaciones).
        /// </summary>
        private void btbListas_Click(object sender, RoutedEventArgs e)
        {
            var wpf = new listasBanda();
            wpf.Show();
        }
    }
}
