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
using ReclutamientoRH.DataContext;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace ReclutamientoRH.Candidatos.DatosPersonales
{
    /// <summary>
    /// Lógica de interacción para editarDatosPersonales.xaml
    /// </summary>
    public partial class editarDatosPersonales : Window
    {
        ViewModels.Candidato candidato;
        int accion;
        DatosPersonales pageDatosPersonales;

        //Identificadores para accion enviada por el boton Editar
        enum Edicion
        {
            Nombre = 1,
            Cedula = 2,
            Usuario = 3,
            Clave = 4
        }
        public editarDatosPersonales()
        {
            InitializeComponent();
        }
        public editarDatosPersonales(ViewModels.Candidato candidato, int accion, DatosPersonales pageDatosPersonales)
        {
            InitializeComponent();
            this.candidato = candidato;
            this.accion = accion;
            this.pageDatosPersonales = pageDatosPersonales;
            setVentana(accion);
        }
        
        private void setVentana(int accion)
        {
            if (accion == (int)Edicion.Cedula)
            {
                Title = "Editar Cedula";
                Info.Content = "Edite la Cedula de sus Datos Personales";
                Dato.Text = candidato.Cedula;
                NombreDato.Content = "Cedula:";
                /*
                delegar = new _delegate(filtroSoloNumeros);
                Dato.AddHandler(PreviewTextInputEvent, delegar);
                 */
                Dato.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.filtroSoloNumeros);
                Dato.MaxLength = 11;
            }
            else if(accion == (int)Edicion.Nombre)
            {
                Title = "Editar Nombre";
                Info.Content = "Edite los Nombres de sus Datos Personales";
                Dato.Text = candidato.Nombre;
                NombreDato.Content = "Nombres:";
                Dato.MaxLength = 45;
            }
            else if (accion == (int)Edicion.Usuario)
            {
                Title = "Editar Usuario";
                Info.Content = "Edite el Usuario de Inicio de Sesión";
                Dato.Text = candidato.Usuario;
                NombreDato.Content = "Usuario:";
                Dato.MaxLength = 20;
            }
        }

        private void guardar(object sender, RoutedEventArgs e)
        {
            if (Dato.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos", "Advertencia");
            }
            else
            { 
                using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                {
                    var comp = db.Candidatos.Where(x => x.Id == candidato.Id).FirstOrDefault();
                    if (accion == (int)Edicion.Cedula)
                    {
                        comp.Cedula = Dato.Text;
                    }
                    else if (accion == (int)Edicion.Nombre)
                    {
                        comp.Nombre = Dato.Text;
                    }
                    else if (accion == (int)Edicion.Usuario)
                    {
                        comp.Usuario = Dato.Text;
                    }
                    db.Entry(comp).State = EntityState.Modified;
                    db.SaveChanges();
                }
                pageDatosPersonales.listar();
                Close();
            }
        }

        private void cancelar(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void filtroSoloNumeros(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
