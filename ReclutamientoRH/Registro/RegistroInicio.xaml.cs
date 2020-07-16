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
using ReclutamientoRH.Login;

namespace ReclutamientoRH.Registro
{
    /// <summary>
    /// Lógica de interacción para RegistroInicio.xaml
    /// </summary>
    public partial class RegistroInicio : Page
    {
        Registro mainWindow;
        RegistroInicio pageInicio;
        RegistroDatosPersonales pageDatosPersonales;
        RegistroPuesto pagePuesto;
        RegistroFinal pageFinal;
        public RegistroInicio()
        {
            InitializeComponent();
        }

        public RegistroInicio(Registro mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            pageInicio = this;
            pageDatosPersonales = new RegistroDatosPersonales();
            pagePuesto = new RegistroPuesto();
            pageFinal = new RegistroFinal();
        }

        private void atras(object sender, RoutedEventArgs e)
        {
            Login.Login loginWindow = new Login.Login();
            mainWindow.Close();
            loginWindow.Show();
        }

        private void siguiente(object sender, RoutedEventArgs e)
        {
            pageDatosPersonales.setObjetcs(mainWindow, this, pageDatosPersonales, pagePuesto, pageFinal);
            mainWindow.Content = pageDatosPersonales;
        }

        public void setObjetcs(Registro mainWindow, RegistroInicio pageInicio, RegistroDatosPersonales pageDatosPersonales, RegistroPuesto pagePuesto, RegistroFinal pageFinal)
        {
            this.mainWindow = mainWindow;
            this.pageInicio = pageInicio;
            this.pageDatosPersonales = pageDatosPersonales;
            this.pagePuesto = pagePuesto;
            this.pageFinal = pageFinal;
        }
    }
}
