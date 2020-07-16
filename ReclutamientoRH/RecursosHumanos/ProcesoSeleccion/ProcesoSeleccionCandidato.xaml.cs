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
using ReclutamientoRH.RecursosHumanos.ConsultaCandidatos;

namespace ReclutamientoRH.RecursosHumanos.ProcesoSeleccion
{
    /// <summary>
    /// Lógica de interacción para ProcesoSeleccionCandidato.xaml
    /// </summary>
    public partial class ProcesoSeleccionCandidato : Window
    {
        int idCandidato;
        public ConsultaCandidatos.ConsultaCandidatos pageConsulta;


        public ProcesoSeleccionCandidato()
        {
            InitializeComponent();
        }
        
        public ProcesoSeleccionCandidato(int idCandidato, ConsultaCandidatos.ConsultaCandidatos pageConsulta)
        {
            InitializeComponent();
            this.idCandidato = idCandidato;
            this.pageConsulta = pageConsulta;
            SeleccionCandidatoFrame.Content = new ProcesoSeleccionInicio(idCandidato, this);
        }
    }
}
