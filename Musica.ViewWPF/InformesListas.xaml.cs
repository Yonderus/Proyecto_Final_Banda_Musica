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
using Musica.Model.Informes;

namespace Musica.ViewWPF
{
    /// <summary>
    /// <b>Informe de listas</b><br/>
    /// Esta ventana muestra el informe de asignaciones (listas).
    /// </summary>
    public partial class InformesListas : Window
    {
        private readonly InformesApi _informesApi = new InformesApi();
        public InformesListas()
        {
            InitializeComponent();

            var ds = _informesApi.GetListasActuacionesDataSet();
            var rpt = new ListaActuacionInforme();

            rpt.SetDataSource(ds);
            reportViewer.ReportSource = rpt;
        }

        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
        }
    }
}
