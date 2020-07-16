using CrystalDecisions.CrystalReports.Engine;
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

namespace ReclutamientoRH.RecursosHumanos.ConsultarEmpleados
{
    /// <summary>
    /// Lógica de interacción para DetalleEmpleado.xaml
    /// </summary>
    public partial class DetalleEmpleado : Window
    {
        string FechaDesde;
        string FechaHasta;
        public DetalleEmpleado()
        {
            InitializeComponent();
        }

        public DetalleEmpleado(string FechaDesde, string FechaHasta)
        {
            InitializeComponent();
            this.FechaDesde = FechaDesde;
            this.FechaHasta = FechaHasta;
        }

        private void onLoad(object sender, RoutedEventArgs e)
        {
            ReportDocument reportDocument = new ReportDocument();
            //reportDocument.Load(@"C:\Users\JC97\Desktop\Cuatrimestre V\Propietaria\ProyectoFinal\ReclutamientoRH\ReclutamientoRH\Reportes\CrystalReport1.rpt");
            reportDocument.Load(@"C:\Users\JC97\Desktop\Cuatrimestre V\Propietaria\ProyectoFinal\ReclutamientoRH\ReclutamientoRH\Reportes\EmpleadosPorFecha.rpt");
            reportDocument.SetParameterValue("@fechaDesde", FechaDesde);
            reportDocument.SetParameterValue("@fechaHasta", FechaHasta);
            Visualizador.ViewerCore.ReportSource = reportDocument;
            Visualizador.ViewerCore.ToggleSidePanel = SAPBusinessObjects.WPF.Viewer.Constants.SidePanelKind.None;
        }
    }
}
