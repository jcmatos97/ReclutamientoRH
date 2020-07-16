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
using System.Data.Entity;

namespace ReclutamientoRH.RecursosHumanos.ProcesoSeleccion
{
    /// <summary>
    /// Lógica de interacción para ProcesoSeleccionInicio.xaml
    /// </summary>
    public partial class ProcesoSeleccionInicio : Page
    {
        public int idCandidato;
        ProcesoSeleccionCandidato window;

        ProcesoSeleccionInicio pInicio;
        ProcesoSeleccionDatos pDatos;
        ProcesoSeleccionFinal pFinal;

        public ProcesoSeleccionInicio()
        {
            InitializeComponent();
        }
        public ProcesoSeleccionInicio(int idCandidato, ProcesoSeleccionCandidato window)
        {
            InitializeComponent();
            this.window = window;
            this.idCandidato = idCandidato;
            pInicio = this;
            pDatos = new ProcesoSeleccionDatos();
            pFinal = new ProcesoSeleccionFinal();
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var data = db.Candidatos.Where(x => x.Id == idCandidato).Select(x => new { Nombre = x.Nombre, Cedula = x.Cedula, Usuario = x.Usuario}).FirstOrDefault();
                pDatos.Nombre.Text = data.Nombre;
                pDatos.Usuario.Text = data.Usuario;
                pDatos.Cedula.Text = data.Cedula;
            }
        }

        private void siguiente(object sender, RoutedEventArgs e)
        {
            pDatos.setObjects(window, this, pDatos, pFinal);
            window.Content = pDatos;
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
