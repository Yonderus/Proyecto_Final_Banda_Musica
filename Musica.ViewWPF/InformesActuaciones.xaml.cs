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
    /// <b>Informe de actuaciones</b><br/>
    /// Esta ventana muestra el informe con las actuaciones.
    /// </summary>
    public partial class InformesActuaciones : Window
    {
        private readonly InformesApi _informesApi = new InformesApi();
        public InformesActuaciones()
        {
            InitializeComponent();

            var ds = _informesApi.GetActuacionesDataSet();
            var rpt = new ActuacionesInforme();

            rpt.SetDataSource(ds);
            reportViewer.ReportSource = rpt;
        }

        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
        }
    }
}
