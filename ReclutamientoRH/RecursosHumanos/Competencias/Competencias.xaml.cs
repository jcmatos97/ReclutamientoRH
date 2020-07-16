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
using System.Data.Entity;

namespace ReclutamientoRH.RecursosHumanos.Competencias
{
    /// <summary>
    /// Lógica de interacción para Competencias.xaml
    /// </summary>
    public partial class Competencias : Page
    {
        public Competencias()
        {
            InitializeComponent();
            Listar();
        }
        public void Listar()
        {
            List<ViewModels.Competencia> comp = new List<ViewModels.Competencia>();
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var consulta = db.Competencias.Where(x => x.Estado == 1).ToList();
                foreach (var item in consulta)
                {
                    comp.Add(new ViewModels.Competencia()
                    {
                        Id = item.Id,
                        Nombre = item.Nombre
                    });
                }
            }
            Tabla.ItemsSource = comp;
        }

        private void Eliminar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            #region EliminarRegistroRaiz
            /*
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var comp = db.Competencias.Where(x => x.Id == id).FirstOrDefault();
                db.Competencias.Remove(comp);
                db.SaveChanges();
            }
            */
            #endregion
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var comp = db.Competencias.Where(x => x.Id == id).FirstOrDefault();
                comp.Estado = 0;
                db.Entry(comp).State = EntityState.Modified;
                db.SaveChanges();
            }
            Listar();
        }

        private void Editar(object sender, RoutedEventArgs e)
        {
            ViewModels.Competencia comp = new ViewModels.Competencia();
            int id = (int)((Button)sender).CommandParameter;
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var dbcomp = db.Competencias.Where(x => x.Id == id).FirstOrDefault();
                comp.Id = dbcomp.Id;
                comp.Nombre = dbcomp.Nombre;
            }
            CompetenciasAddUpdate windw = new CompetenciasAddUpdate(comp, this);
            windw.Show();
        }

        private void Crear(object sender, RoutedEventArgs e)
        {
            CompetenciasAddUpdate windw = new CompetenciasAddUpdate(this);
            windw.Show();
        }
    }
}
