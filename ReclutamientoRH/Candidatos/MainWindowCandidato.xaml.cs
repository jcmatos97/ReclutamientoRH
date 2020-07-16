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
using ReclutamientoRH.ViewModels;
using ReclutamientoRH.Candidatos.Inicio;

namespace ReclutamientoRH.Candidatos
{
    /// <summary>
    /// Lógica de interacción para MainWindowCandidato.xaml
    /// </summary>
    public partial class MainWindowCandidato : Window
    {
        public Candidato candidato;
        public MainWindowCandidato()
        {
            InitializeComponent();
        }

        public MainWindowCandidato(Candidato candidato)
        {
            InitializeComponent();
            this.candidato = candidato;
            CandidatoMainFrame.Content = new Inicio.Inicio(candidato);
        }
        //Inicio
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            CandidatoMainFrame.Content = new Inicio.Inicio(candidato);
        }
        //Competencias
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            CandidatoMainFrame.Content = new Competencias.Competencias(candidato);
        }

        //Idiomas
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            CandidatoMainFrame.Content = new Idiomas.Idiomas(candidato);
        }
        //Capacitaciones
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            CandidatoMainFrame.Content = new Capacitaciones.Capacitaciones(candidato);
        }
        //Experiencia
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            CandidatoMainFrame.Content = new Experiencia.Experiencia(candidato);
        }
        //Datos Personales
        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            CandidatoMainFrame.Content = new DatosPersonales.DatosPersonales(candidato);
        }
        //Datos Vacante Solicitada
        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            CandidatoMainFrame.Content = new DatosVacante.DatosVacante(candidato);
        }
        //Ayuda
        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Version 1.0 \nCreado por jcmatos97 - 2020", "Información");
        }
    }
}
