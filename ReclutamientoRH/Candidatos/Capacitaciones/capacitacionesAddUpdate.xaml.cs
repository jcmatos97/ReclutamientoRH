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
using ReclutamientoRH.Candidatos.Capacitaciones;
using ReclutamientoRH.DataContext;
using System.Data.Entity;
using ReclutamientoRH.ViewModels;

namespace ReclutamientoRH.Candidatos.Capacitaciones
{
    /// <summary>
    /// Lógica de interacción para capacitacionesAddUpdate.xaml
    /// </summary>
    public partial class capacitacionesAddUpdate : Window
    {
        ViewModels.Capacitaciones modelCapacitaciones;
        Capacitaciones pageCapacitaciones;
        ViewModels.Candidato candidato;
        public capacitacionesAddUpdate(Capacitaciones pageCapacitaciones, ViewModels.Candidato candidato)
        {
            InitializeComponent();
            Title = "Agregar Capacitación";
            Info.Content = "Agrege una Capacitación a su Historial:";
            AgregarActualizar.Content = "Agregar";
            FechaDesde.SelectedDate = DateTime.Today;
            FechaHasta.SelectedDate = DateTime.Today;
            this.pageCapacitaciones = pageCapacitaciones;
            this.candidato = candidato;
        }

        public capacitacionesAddUpdate(ViewModels.Capacitaciones modelCapacitaciones, Capacitaciones pageCapacitaciones, ViewModels.Candidato candidato)
        {
            InitializeComponent();
            Title = "Editar Capacitación";
            Info.Content = "Edite una Capacitación de su Historial:";
            AgregarActualizar.Content = "Editar";
            Nombre.Text = modelCapacitaciones.Nombre;
            Nivel.Text = modelCapacitaciones.Nivel;
            FechaDesde.SelectedDate = new DateTime(Convert.ToDateTime(modelCapacitaciones.FechaDesde).Year, Convert.ToDateTime(modelCapacitaciones.FechaDesde).Month, Convert.ToDateTime(modelCapacitaciones.FechaDesde).Day);
            FechaHasta.SelectedDate = new DateTime(Convert.ToDateTime(modelCapacitaciones.FechaHasta).Year, Convert.ToDateTime(modelCapacitaciones.FechaHasta).Month, Convert.ToDateTime(modelCapacitaciones.FechaHasta).Day);
            Institucion.Text = modelCapacitaciones.Institucion;
            this.modelCapacitaciones = modelCapacitaciones;
            this.pageCapacitaciones = pageCapacitaciones;
            this.candidato = candidato;
        }

        private void agregarActualizar(object sender, RoutedEventArgs e)
        {
            if (modelCapacitaciones == null)
            {
                if ((Nombre.Text == "") || (Nivel.Text == "") || (FechaDesde.Text == "") || (FechaHasta.Text == "") || (Institucion.Text == ""))
                {
                    MessageBox.Show("Debe completar todos los campos", "Advertencia");
                }
                else
                { 
                    using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                    {
                        var dataCapacitaciones = new DataContext.Capacitacione()
                        {
                            Nombre = Nombre.Text,
                            Nivel = Nivel.Text,
                            FechaDesde = (DateTime)FechaDesde.SelectedDate,
                            FechaHasta = (DateTime)FechaHasta.SelectedDate,
                            Institucion = Institucion.Text,
                            IdCandidato = candidato.Id
                        };
                        db.Capacitaciones.Add(dataCapacitaciones);
                        db.SaveChanges();
                    }                
                    pageCapacitaciones.listar();
                    Close();
                }
            }
            if (modelCapacitaciones != null)
            {
                if ((Nombre.Text == "") || (Nivel.Text == "") || (FechaDesde.Text == "") || (FechaHasta.Text == "") || (Institucion.Text == ""))
                {
                    MessageBox.Show("Debe completar todos los campos", "Advertencia");
                }
                else
                {
                    using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                    {
                        var dataCapacitacion = db.Capacitaciones.Where(x => x.Id == this.modelCapacitaciones.Id).FirstOrDefault();
                        dataCapacitacion.Nombre = Nombre.Text;
                        dataCapacitacion.Nivel = Nivel.Text;
                        dataCapacitacion.FechaDesde = (DateTime)FechaDesde.SelectedDate;
                        dataCapacitacion.FechaHasta = (DateTime)FechaHasta.SelectedDate;
                        dataCapacitacion.Institucion = Institucion.Text;
                        db.Entry(dataCapacitacion).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    pageCapacitaciones.listar();
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
