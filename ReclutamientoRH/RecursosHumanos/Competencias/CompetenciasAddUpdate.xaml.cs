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

namespace ReclutamientoRH.RecursosHumanos.Competencias
{
    /// <summary>
    /// Lógica de interacción para CompetenciasAddUpdate.xaml
    /// </summary>
    public partial class CompetenciasAddUpdate : Window
    {
        ViewModels.Competencia comp;
        Competencias windowComp;

        public CompetenciasAddUpdate(Competencias windowComp)
        {
            InitializeComponent();
            Title = "Agregar Competencia";
            Info.Content = "Digite el nombre de una Competencia";
            AgregarActualizar.Content = "Agregar";
            this.windowComp = windowComp;
        }
        public CompetenciasAddUpdate(ViewModels.Competencia comp, Competencias windowComp)
        {
            InitializeComponent();
            this.comp = comp;
            Title = "Editar Competencia";
            Info.Content = "Edite el nombre de la Competencia";
            AgregarActualizar.Content = "Editar";
            nombre.Text = comp.Nombre;
            this.windowComp = windowComp;
        }

        private void agregarActualizar(object sender, RoutedEventArgs e)
        {
            if(comp == null)
            {
                    if (nombre.Text == "")
                    {
                        MessageBox.Show("Debe completar todos los campos", "Advertencia");
                    }
                    else
                    {
                        using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                        {
                            var comp = new DataContext.Competencia() { Nombre = nombre.Text, Estado = 1};
                            db.Competencias.Add(comp);
                            db.SaveChanges();
                        }
                        windowComp.Listar();
                        Close();
                }
            }            
            if(comp != null)
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
                        var comp = db.Competencias.Where(x => x.Id == this.comp.Id).FirstOrDefault();
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
