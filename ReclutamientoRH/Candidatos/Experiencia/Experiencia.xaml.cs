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
using System.Data.Entity;

namespace ReclutamientoRH.Candidatos.Experiencia
{
    /// <summary>
    /// Lógica de interacción para Experiencia.xaml
    /// </summary>
    public partial class Experiencia : Page
    {
        public ViewModels.Candidato candidato;
        public Experiencia()
        {
            InitializeComponent();
        }
        public Experiencia(ViewModels.Candidato candidato)
        {
            InitializeComponent();
            this.candidato = candidato;
            listar();
        }
        public void listar()
        {
            List<ViewModels.Experiencia> comp = new List<ViewModels.Experiencia>();
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var consulta = db.ExperienciaLaborals.Where(x => x.IdCandidato == candidato.Id).ToList();
                foreach (var item in consulta)
                {
                    comp.Add(new ViewModels.Experiencia()
                    {
                        Id = item.Id,
                        Empresa = item.Empresa,
                        Puesto = item.Puesto,
                        FechaDesde = item.FechaDesde.ToShortDateString(),
                        FechaHasta = item.FechaHasta.ToShortDateString(),
                        Salario = (decimal)item.Salario
                    });
                }
            }
            Tabla.ItemsSource = comp;
        }

        private void Editar(object sender, RoutedEventArgs e)
        {
            ViewModels.Experiencia experiencia = new ViewModels.Experiencia();
            int id = (int)((Button)sender).CommandParameter;
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var dbcap = db.ExperienciaLaborals.Where(x => x.Id == id).FirstOrDefault();
                experiencia.Id = dbcap.Id;
                experiencia.Empresa = dbcap.Empresa;
                experiencia.Puesto = dbcap.Puesto;
                experiencia.FechaDesde = dbcap.FechaDesde.ToShortDateString();
                experiencia.FechaHasta = dbcap.FechaHasta.ToShortDateString();
                experiencia.Salario = (decimal)dbcap.Salario;
            }
            experienciaAddUpdate windw = new experienciaAddUpdate(experiencia, this, candidato);
            windw.Show();
        }

        private void Eliminar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;

            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var experiencia = db.ExperienciaLaborals.Where(x => x.Id == id).FirstOrDefault();
                db.ExperienciaLaborals.Remove(experiencia);
                db.SaveChanges();
            }
            listar();
        }

        private void Crear(object sender, RoutedEventArgs e)
        {
            experienciaAddUpdate window = new experienciaAddUpdate(this, candidato);
            window.Show();
        }
    }
}
