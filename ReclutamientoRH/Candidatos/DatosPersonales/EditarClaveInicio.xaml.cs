using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using ReclutamientoRH.ViewModels;

namespace ReclutamientoRH.Candidatos.DatosPersonales
{
    /// <summary>
    /// Lógica de interacción para EditarClaveInicio.xaml
    /// </summary>
    public partial class EditarClaveInicio : Page
    {
        ViewModels.Candidato candidato;
        editarClave windowEditarClave;
        public EditarClaveInicio()
        {
            InitializeComponent();
        }        
        public EditarClaveInicio(ViewModels.Candidato candidato, editarClave windowEditarClave)
        {
            InitializeComponent();
            this.candidato = candidato;
            this.windowEditarClave = windowEditarClave;
        }

        private void acceder(object sender, RoutedEventArgs e)
        {
            Login.Login login = new Login.Login();
            string claveIngresada = login.GetMd5Hash(MD5.Create(), clave.Password.ToString());

            if (candidato.Clave == claveIngresada)
            {
                windowEditarClave.Content = new EditarClaveFinal(candidato, windowEditarClave);
            }
            else if (candidato.Clave != claveIngresada)
            {
                MessageBox.Show("Acceso Denegado \nVerifica tus credenciales e intenta de nuevo");
                clave.Password = "";
            }
            login.Close();
        }

        private void cancelar(object sender, RoutedEventArgs e)
        {
            windowEditarClave.Close();
        }
    }
}
