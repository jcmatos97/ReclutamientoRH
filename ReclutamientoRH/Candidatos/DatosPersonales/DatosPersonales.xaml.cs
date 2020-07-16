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
using ReclutamientoRH.ViewModels;
using ReclutamientoRH.DataContext;

namespace ReclutamientoRH.Candidatos.DatosPersonales
{
    /// <summary>
    /// Lógica de interacción para DatosPersonales.xaml
    /// </summary>
    public partial class DatosPersonales : Page
    {
        ViewModels.Candidato candidato;
       
        //Identificadores para accion enviada por el boton Editar
        enum Edicion
        {
            Nombre = 1,
            Cedula = 2,
            Usuario = 3,
            Clave = 4
        }
        public DatosPersonales()
        {
            InitializeComponent();
        }
        public DatosPersonales(ViewModels.Candidato candidato)
        {
            InitializeComponent();
            this.candidato = candidato;
            listar();
        }

        public void listar()
        {
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var content = db.Candidatos.Where(x => x.Id == candidato.Id).FirstOrDefault();
                candidato.Id = content.Id;
                candidato.Nombre = content.Nombre;
                candidato.Cedula = content.Cedula;
                candidato.Usuario = content.Usuario;
                candidato.Clave = content.Clave;
                candidato.SalarioAspiracion = Convert.ToDecimal(content.SalarioAspiracion);
                candidato.RecomendadoPor = content.RecomendadoPor;
                candidato.IdPuesto = content.IdPuesto;
            }
            Nombre.Text = candidato.Nombre;
            Cedula.Text = candidato.Cedula;
            Usuario.Text = candidato.Usuario;
        }
        private void Editar(object sender, RoutedEventArgs e)
        {
            int accion = Convert.ToInt32(((Button)sender).CommandParameter.ToString());
            if(accion == (int)Edicion.Nombre)
            {
                editarDatosPersonales editWindow = new editarDatosPersonales(candidato, accion, this);
                editWindow.Show();
            }
            else if(accion == (int)Edicion.Cedula)
            {
                editarDatosPersonales editWindow = new editarDatosPersonales(candidato, accion, this);
                editWindow.Show();
            }
            else if(accion == (int)Edicion.Usuario)
            {
                editarDatosPersonales editWindow = new editarDatosPersonales(candidato, accion, this);
                editWindow.Show();
            }
            else if (accion == (int)Edicion.Clave)
            {
                editarClave editWindow = new editarClave(candidato);
                editWindow.Show();
            }
        }
    }
}
