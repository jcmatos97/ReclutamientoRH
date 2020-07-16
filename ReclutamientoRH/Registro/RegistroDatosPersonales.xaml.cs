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
using System.Text.RegularExpressions;

namespace ReclutamientoRH.Registro
{
    /// <summary>
    /// Lógica de interacción para RegistroDatosPersonales.xaml
    /// </summary>
    public partial class RegistroDatosPersonales : Page
    {
        Registro mainWindow;
        RegistroInicio pageInicio;
        RegistroDatosPersonales pageDatosPersonales;
        RegistroPuesto pagePuesto;
        RegistroFinal pageFinal;
        public RegistroDatosPersonales()
        {
            InitializeComponent();
        }

        private void atras(object sender, RoutedEventArgs e)
        {
            pageInicio.setObjetcs(mainWindow, pageInicio, this, pagePuesto, pageFinal);
            mainWindow.Content = pageInicio;
        }

        private void siguiente(object sender, RoutedEventArgs e)
        {
            pagePuesto.setObjetcs(mainWindow, pageInicio, this, pagePuesto, pageFinal);
            mainWindow.Content = pagePuesto;
        }

        public void setObjetcs(Registro mainWindow, RegistroInicio pageInicio, RegistroDatosPersonales pageDatosPersonales, RegistroPuesto pagePuesto, RegistroFinal pageFinal)
        {
            this.mainWindow = mainWindow;
            this.pageInicio = pageInicio;
            this.pageDatosPersonales = pageDatosPersonales;
            this.pagePuesto = pagePuesto;
            this.pageFinal = pageFinal;
        }
        private void filtroSoloNumeros(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
