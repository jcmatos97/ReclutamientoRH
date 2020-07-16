using ReclutamientoRH.DataContext;
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
using System.Data.Entity;

namespace ReclutamientoRH.RecursosHumanos.ConsultarEmpleados
{
    /// <summary>
    /// Lógica de interacción para ConsultarEmpleados.xaml
    /// </summary>
    public partial class ConsultarEmpleados : Page
    {
        public ConsultarEmpleados()
        {
            InitializeComponent();
            FechaDesde.Text = DateTime.Now.ToShortDateString();
            FechaHasta.Text = DateTime.Now.ToShortDateString();
        }


        private void consultar(object sender, RoutedEventArgs e)
        {
            bool boolDesde = (FechaDesde.Text == "") ? false : true;
            bool boolHasta = (FechaHasta.Text == "") ? false : true;

            IQueryable<DataContext.Empleado> queryEmpleado;

            List<EmpleadoViewModel> data = new List<EmpleadoViewModel>();

            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                queryEmpleado = db.Set<DataContext.Empleado>();

                if (boolDesde)
                    queryEmpleado = queryEmpleado.Where(t => t.FechaIngreso >= FechaDesde.DisplayDate);
                if (boolHasta)
                    queryEmpleado = queryEmpleado.Where(t => t.FechaIngreso <= FechaHasta.DisplayDate);

                foreach (var item in queryEmpleado.Include(t => t.Candidato).ToList())
                {
                    data.Add(new EmpleadoViewModel()
                    {
                        Nombre = item.Candidato.Nombre,
                        Cedula = item.Candidato.Cedula,
                        Usuario = item.Candidato.Usuario,
                        Puesto = item.Candidato.Puesto.Nombre,
                        Departamento = item.Candidato.Puesto.Departamento,
                        FechaDeIngreso = item.FechaIngreso.ToShortDateString(),
                        Salario = (decimal)item.Salario
                    });
                }
            }

            Tabla.ItemsSource = data;

        }

        private void limpiarCampos(object sender, RoutedEventArgs e)
        {
            FechaDesde.Text = DateTime.Now.ToShortDateString();
            FechaHasta.Text = DateTime.Now.ToShortDateString();
        }

        private void generarReporte(object sender, RoutedEventArgs e)
        {
            DetalleEmpleado detalleEmpleado = new DetalleEmpleado(FechaDesde.Text, FechaHasta.Text);
            detalleEmpleado.Show();
        }
    }

    public class EmpleadoViewModel: ViewModels.Candidato
    {
        public string Puesto { get; set; }
        public string Departamento { get; set; }
        public decimal Salario { get; set; }
        public string FechaDeIngreso { get; set; }
    }
}
