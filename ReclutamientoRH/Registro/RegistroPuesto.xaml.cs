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
using ReclutamientoRH.DataContext;
using ReclutamientoRH.ViewModels;

namespace ReclutamientoRH.Registro
{
    /// <summary>
    /// Lógica de interacción para RegistroPuesto.xaml
    /// </summary>
    public partial class RegistroPuesto : Page
    {
        Registro mainWindow;
        RegistroInicio pageInicio;
        RegistroDatosPersonales pageDatosPersonales;
        RegistroPuesto pagePuesto;
        RegistroFinal pageFinal;

        //Id de Puesto
        int idPuesto = 0;
        public RegistroPuesto()
        {
            InitializeComponent();
            listarPuestos();
        }

        private void atras(object sender, RoutedEventArgs e)
        {
            pageDatosPersonales.setObjetcs(mainWindow, pageInicio, pageDatosPersonales, this, pageFinal);
            mainWindow.Content = pageDatosPersonales;
        }

        private void siguiente(object sender, RoutedEventArgs e)
        {
            pageFinal.setObjetcs(mainWindow, pageInicio, pageDatosPersonales, this, pageFinal);
            mainWindow.Content = pageFinal;
        }

        private void listarPuestos()
        {
            List<ViewModels.Puesto> puestos = new List<ViewModels.Puesto>();
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var dbPuestos = db.Puestos.Where(x => x.Estado == 1).ToList();
                foreach (var item in dbPuestos)
                {
                    puestos.Add(new ViewModels.Puesto() 
                    { 
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Departamento = item.Departamento,
                        NivelDeRiesgo = item.NivelDeRiesgo
                    });
                }
            }
            Tabla.ItemsSource = puestos;
        }
        public void setObjetcs(Registro mainWindow, RegistroInicio pageInicio, RegistroDatosPersonales pageDatosPersonales, RegistroPuesto pagePuesto, RegistroFinal pageFinal)
        {
            this.mainWindow = mainWindow;
            this.pageInicio = pageInicio;
            this.pageDatosPersonales = pageDatosPersonales;
            this.pagePuesto = pagePuesto;
            this.pageFinal = pageFinal;
        }

        private void getPuesto(object sender, RoutedEventArgs e)
        {
            int idPuesto = (int)((RadioButton)sender).CommandParameter;
            this.idPuesto = idPuesto;
            pageFinal.setIdPuesto(idPuesto);
        }
    }
}
