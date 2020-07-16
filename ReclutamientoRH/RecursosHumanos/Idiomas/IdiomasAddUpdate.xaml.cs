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

namespace ReclutamientoRH.RecursosHumanos.Idiomas
{
    /// <summary>
    /// Lógica de interacción para IdiomasAddUpdate.xaml
    /// </summary>
    public partial class IdiomasAddUpdate : Window
    {
        ViewModels.Idioma comp;
        Idiomas windowComp;

        public IdiomasAddUpdate(Idiomas windowComp)
        {
            InitializeComponent();
            Title = "Agregar Idioma";
            Info.Content = "Digite el nombre de un Idioma";
            AgregarActualizar.Content = "Agregar";
            this.windowComp = windowComp;
        }
        public IdiomasAddUpdate(ViewModels.Idioma comp, Idiomas windowComp)
        {
            InitializeComponent();
            this.comp = comp;
            Title = "Editar Idioma";
            Info.Content = "Edite el nombre del Idioma";
            AgregarActualizar.Content = "Editar";
            nombre.Text = comp.Nombre;
            this.windowComp = windowComp;
        }

        private void agregarActualizar(object sender, RoutedEventArgs e)
        {
            if (comp == null)
            {
                if (nombre.Text == "")
                {
                    MessageBox.Show("Debe completar todos los campos", "Advertencia");
                }
                else
                {
                    using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                    {
                        var comp = new DataContext.Idioma() { Nombre = nombre.Text, Estado = 1 };
                        db.Idiomas.Add(comp);
                        db.SaveChanges();
                    }
                    windowComp.Listar();
                    Close();
                }
            }
            if (comp != null)
            {
                if (nombre.Text == "")
                {
                    MessageBox.Show("Debe completar todos los campos", "Advertencia");
                    nombre.Text = comp.Nombre;
                }
                else 
                { 
                    using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                    {
                        var comp = db.Idiomas.Where(x => x.Id == this.comp.Id).FirstOrDefault();
                        comp.Nombre = nombre.Text;
                        db.Entry(comp).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    windowComp.Listar();
                    Close();
                }
            }
        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
