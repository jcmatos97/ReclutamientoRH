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
using System.Data.Entity;
using ReclutamientoRH.DataContext;
using ReclutamientoRH.ViewModels;
using ReclutamientoRH.RecursosHumanos;
using ReclutamientoRH.Reportes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ReclutamientoRH.RecursosHumanos.ConsultaCandidatos
{
    /// <summary>
    /// Lógica de interacción para DetalleCandidato.xaml
    /// </summary>
    public partial class DetalleCandidato : Window
    {
        int idCandidato;
        public DetalleCandidato()
        {
            InitializeComponent();
        }
        public DetalleCandidato(int idCandidato)
        {
            InitializeComponent();
            this.idCandidato = idCandidato;

        }

        private void onLoad(object sender, RoutedEventArgs e)
        {
            ReportDocument reportDocument = new ReportDocument();
            //reportDocument.Load(@"C:\Users\JC97\Desktop\Cuatrimestre V\Propietaria\ProyectoFinal\ReclutamientoRH\ReclutamientoRH\Reportes\CrystalReport1.rpt");
            reportDocument.Load(@"C:\Users\JC97\Desktop\Cuatrimestre V\Propietaria\ProyectoFinal\ReclutamientoRH\ReclutamientoRH\Reportes\DetalleCandidato.rpt");
            reportDocument.SetParameterValue("@idCandidato", idCandidato);
            reportDocument.SetParameterValue("@idCandidato", idCandidato, reportDocument.Subreports[0].Name.ToString());
            reportDocument.SetParameterValue("@idCandidato", idCandidato, reportDocument.Subreports[1].Name.ToString());
            reportDocument.SetParameterValue("@idCandidato", idCandidato, reportDocument.Subreports[2].Name.ToString());
            reportDocument.SetParameterValue("@idCandidato", idCandidato, reportDocument.Subreports[3].Name.ToString());
            Visualizador.ViewerCore.ReportSource = reportDocument;
            Visualizador.ViewerCore.ToggleSidePanel = SAPBusinessObjects.WPF.Viewer.Constants.SidePanelKind.None;
        }
    }
}
