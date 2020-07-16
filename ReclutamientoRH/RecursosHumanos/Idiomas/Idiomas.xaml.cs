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

namespace ReclutamientoRH.RecursosHumanos.Idiomas
{
    /// <summary>
    /// Lógica de interacción para Idiomas.xaml
    /// </summary>
    public partial class Idiomas : Page
    {
        public Idiomas()
        {
            InitializeComponent();
            Listar();
        }
        public void Listar()
        {
            List<ViewModels.Idioma> comp = new List<ViewModels.Idioma>();
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var consulta = db.Idiomas.Where(x => x.Estado == 1).ToList();
                foreach (var item in consulta)
                {
                    comp.Add(new ViewModels.Idioma()
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
           
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var comp = db.Idiomas.Where(x => x.Id == id).FirstOrDefault();
                comp.Estado = 0;
                db.Entry(comp).State = EntityState.Modified;
                db.SaveChanges();
            }
            Listar();
        }

        private void Editar(object sender, RoutedEventArgs e)
        {
            ViewModels.Idioma comp = new ViewModels.Idioma();
            int id = (int)((Button)sender).CommandParameter;
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var dbcomp = db.Idiomas.Where(x => x.Id == id).FirstOrDefault();
                comp.Id = dbcomp.Id;
                comp.Nombre = dbcomp.Nombre;
            }
            IdiomasAddUpdate windw = new IdiomasAddUpdate(comp, this);
            windw.Show();
        }

        private void Crear(object sender, RoutedEventArgs e)
        {
            IdiomasAddUpdate windw = new IdiomasAddUpdate(this);
            windw.Show();
        }

    }
}
