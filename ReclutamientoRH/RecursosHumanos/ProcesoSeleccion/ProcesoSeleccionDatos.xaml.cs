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

namespace ReclutamientoRH.RecursosHumanos.ProcesoSeleccion
{
    /// <summary>
    /// Lógica de interacción para ProcesoSeleccionDatos.xaml
    /// </summary>
    public partial class ProcesoSeleccionDatos : Page
    {
        ProcesoSeleccionCandidato window;

        ProcesoSeleccionInicio pInicio;
        ProcesoSeleccionDatos pDatos;
        ProcesoSeleccionFinal pFinal;
        public ProcesoSeleccionDatos()
        {
            InitializeComponent();
            Salario.Focus();
        }

        private void atras(object sender, RoutedEventArgs e)
        {
            pInicio.setObjects(window, pInicio, this, pFinal);
            window.Content = pInicio;
        }

        private void siguiente(object sender, RoutedEventArgs e)
        {
            pFinal.setObjects(window, pInicio, this, pFinal);
            window.Content = pFinal;
        }

        public void setObjects(ProcesoSeleccionCandidato window, ProcesoSeleccionInicio pInicio, ProcesoSeleccionDatos pDatos, ProcesoSeleccionFinal pFinal)
        {
            this.window = window;
            this.pInicio = pInicio;
            this.pDatos = pDatos;
            this.pFinal = pFinal;
        }
    }
}
