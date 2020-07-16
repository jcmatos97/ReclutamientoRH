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
using ReclutamientoRH.DataContext;
using System.Data.Entity;
using ReclutamientoRH.ViewModels;


namespace ReclutamientoRH.Candidatos.Experiencia
{
    /// <summary>
    /// Lógica de interacción para experienciaAddUpdate.xaml
    /// </summary>
    public partial class experienciaAddUpdate : Window
    {
        ViewModels.Experiencia modelExperiencia;
        Experiencia pageExperiencia;
        ViewModels.Candidato candidato;
        public experienciaAddUpdate(Experiencia pageExperiencia, ViewModels.Candidato candidato)
        {
            InitializeComponent();
            Title = "Agregar Experiencia Laboral";
            Info.Content = "Agrege una Experiencia Laboral a su Historial:";
            AgregarActualizar.Content = "Agregar";
            FechaDesde.SelectedDate = DateTime.Today;
            FechaHasta.SelectedDate = DateTime.Today;
            this.pageExperiencia = pageExperiencia;
            this.candidato = candidato;
        }
        public experienciaAddUpdate(ViewModels.Experiencia modelExperiencia, Experiencia pageExperiencia, ViewModels.Candidato candidato)
        {
            InitializeComponent();
            Title = "Editar Experiencia Laboral";
            Info.Content = "Edite una Experiencia Laboral de su Historial:";
            AgregarActualizar.Content = "Editar";
            Empresa.Text = modelExperiencia.Empresa;
            Puesto.Text = modelExperiencia.Puesto;
            FechaDesde.SelectedDate = new DateTime(Convert.ToDateTime(modelExperiencia.FechaDesde).Year, Convert.ToDateTime(modelExperiencia.FechaDesde).Month, Convert.ToDateTime(modelExperiencia.FechaDesde).Day);
            FechaHasta.SelectedDate = new DateTime(Convert.ToDateTime(modelExperiencia.FechaHasta).Year, Convert.ToDateTime(modelExperiencia.FechaHasta).Month, Convert.ToDateTime(modelExperiencia.FechaHasta).Day);
            Salario.Text = Convert.ToString(modelExperiencia.Salario);
            this.modelExperiencia = modelExperiencia;
            this.pageExperiencia = pageExperiencia;
            this.candidato = candidato;
        }

        private void agregarActualizar(object sender, RoutedEventArgs e)
        {
            if (modelExperiencia == null)
            {
                if ((Empresa.Text == "") || (Puesto.Text == "") || (FechaDesde.Text == "") || (FechaHasta.Text == "") || (Salario.Text == ""))
                {
                    MessageBox.Show("Debe completar todos los campos", "Advertencia");
                }
                else
                { 
                    using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                    {
                        var dataExperiencia = new DataContext.ExperienciaLaboral()
                        {
                            Empresa = Empresa.Text,
                            Puesto = Puesto.Text,
                            FechaDesde = (DateTime)FechaDesde.SelectedDate,
                            FechaHasta = (DateTime)FechaHasta.SelectedDate,
                            Salario = Convert.ToDecimal(Salario.Text),
                            IdCandidato = candidato.Id
                        };
                        db.ExperienciaLaborals.Add(dataExperiencia);
                        db.SaveChanges();
                    }
                    pageExperiencia.listar();
                    Close();
                }
            }
            if (modelExperiencia != null)
            {
                if ((Empresa.Text == "") || (Puesto.Text == "") || (FechaDesde.Text == "") || (FechaHasta.Text == "") || (Salario.Text == ""))
                {
                    MessageBox.Show("Debe completar todos los campos", "Advertencia");
                }
                else
                {
                    using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                    {
                        var dataExperiencia = db.ExperienciaLaborals.Where(x => x.Id == this.modelExperiencia.Id).FirstOrDefault();
                        dataExperiencia.Empresa = Empresa.Text;
                        dataExperiencia.Puesto = Puesto.Text;
                        dataExperiencia.FechaDesde = (DateTime)FechaDesde.SelectedDate;
                        dataExperiencia.FechaHasta = (DateTime)FechaHasta.SelectedDate;
                        dataExperiencia.Salario = Convert.ToDecimal(Salario.Text);
                        db.Entry(dataExperiencia).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    pageExperiencia.listar();
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
