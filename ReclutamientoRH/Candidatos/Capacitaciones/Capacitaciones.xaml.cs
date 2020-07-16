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

namespace ReclutamientoRH.Candidatos.Capacitaciones
{
    /// <summary>
    /// Lógica de interacción para Capacitaciones.xaml
    /// </summary>
    public partial class Capacitaciones : Page
    {
        public ViewModels.Candidato candidato;
        public Capacitaciones()
        {
            InitializeComponent();
        }

        public Capacitaciones(ViewModels.Candidato candidato)
        {
            InitializeComponent();
            this.candidato = candidato;
            listar();
        }

        public void listar()
        {
            List<ViewModels.Capacitaciones> comp = new List<ViewModels.Capacitaciones>();
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var consulta = db.Capacitaciones.Where(x => x.IdCandidato == candidato.Id).ToList();
                foreach (var item in consulta)
                {
                    comp.Add(new ViewModels.Capacitaciones()
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Nivel = item.Nivel,
                        FechaDesde = item.FechaDesde.ToShortDateString(),
                        FechaHasta = item.FechaHasta.ToShortDateString(),
                        Institucion = item.Institucion,
                    });
                }
            }
            Tabla.ItemsSource = comp;
        }

        private void Editar(object sender, RoutedEventArgs e)
        {
            ViewModels.Capacitaciones capacitacion = new ViewModels.Capacitaciones();
            int id = (int)((Button)sender).CommandParameter;
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var dbcap = db.Capacitaciones.Where(x => x.Id == id).FirstOrDefault();
                capacitacion.Id = dbcap.Id;
                capacitacion.Nombre = dbcap.Nombre;
                capacitacion.Nivel = dbcap.Nivel;
                capacitacion.FechaDesde = dbcap.FechaDesde.ToShortDateString();
                capacitacion.FechaHasta = dbcap.FechaHasta.ToShortDateString();
                capacitacion.Institucion = dbcap.Institucion;
            }
            capacitacionesAddUpdate windw = new capacitacionesAddUpdate(capacitacion, this, candidato);
            windw.Show();
        }

        private void Eliminar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;

            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var capacitaciones = db.Capacitaciones.Where(x => x.Id == id).FirstOrDefault();
                db.Capacitaciones.Remove(capacitaciones);
                db.SaveChanges();
            }
            listar();
        }

        private void Crear(object sender, RoutedEventArgs e)
        {
            capacitacionesAddUpdate window = new capacitacionesAddUpdate(this, candidato);
            window.Show();
        }
    }
}
