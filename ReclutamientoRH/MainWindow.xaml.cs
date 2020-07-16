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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReclutamientoRH.RecursosHumanos.Inicio;
using ReclutamientoRH.RecursosHumanos.Competencias;
using ReclutamientoRH.RecursosHumanos.Idiomas;
using ReclutamientoRH.RecursosHumanos.Puestos;
using ReclutamientoRH.RecursosHumanos.ConsultaCandidatos;
using ReclutamientoRH.RecursosHumanos.ProcesoSeleccion;
using ReclutamientoRH.RecursosHumanos.ConsultarEmpleados;

namespace ReclutamientoRH
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new Inicio();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Inicio();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Competencias();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Idiomas();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Puestos();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ConsultaCandidatos();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ConsultarEmpleados();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Version 1.0 \nCreado por jcmatos97 - 2020", "Información");
        }

    }
}
