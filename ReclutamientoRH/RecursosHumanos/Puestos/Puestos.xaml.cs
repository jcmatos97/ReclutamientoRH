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

namespace ReclutamientoRH.RecursosHumanos.Puestos
{
    /// <summary>
    /// Lógica de interacción para Puestos.xaml
    /// </summary>
    public partial class Puestos : Page
    {
        public Puestos()
        {
            InitializeComponent();
            Listar();
        }
        public void Listar()
        {
            List<ViewModels.Puesto> comp = new List<ViewModels.Puesto>();
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var consulta = db.Puestos.Where(x => x.Estado == 1).ToList();
                foreach (var item in consulta)
                {
                    comp.Add(new ViewModels.Puesto()
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Departamento = item.Departamento,
                        NivelDeRiesgo = item.NivelDeRiesgo,
                        NivelMinSalario = (decimal)item.NivelMinSalario,
                        NivelMaxSalario = (decimal)item.NivelMaxSalario
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
                var comp = db.Puestos.Where(x => x.Id == id).FirstOrDefault();
                comp.Estado = 0;
                db.Entry(comp).State = EntityState.Modified;
                db.SaveChanges();
            }
            Listar();
        }
        //Crear puestosAddUpdate xml y cs
        private void Editar(object sender, RoutedEventArgs e)
        {
            ViewModels.Puesto comp = new ViewModels.Puesto();
            int id = (int)((Button)sender).CommandParameter;
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var dbcomp = db.Puestos.Where(x => x.Id == id).FirstOrDefault();
                comp.Id = dbcomp.Id;
                comp.Nombre = dbcomp.Nombre;
                comp.Departamento = dbcomp.Departamento;
                comp.NivelDeRiesgo = dbcomp.NivelDeRiesgo;
                comp.NivelMinSalario = Convert.ToDecimal(dbcomp.NivelMinSalario);
                comp.NivelMaxSalario = Convert.ToDecimal(dbcomp.NivelMaxSalario);
            }
            puestosAddUpdate windw = new puestosAddUpdate(comp, this);
            windw.Show();
        }

        private void Crear(object sender, RoutedEventArgs e)
        {
            puestosAddUpdate window = new puestosAddUpdate(this);
            window.Show();
        }
    }
}
