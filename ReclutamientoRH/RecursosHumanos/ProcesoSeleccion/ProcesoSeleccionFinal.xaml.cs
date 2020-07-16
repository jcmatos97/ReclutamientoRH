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
using System.Data.Entity;

namespace ReclutamientoRH.RecursosHumanos.ProcesoSeleccion
{
    /// <summary>
    /// Lógica de interacción para ProcesoSeleccionFinal.xaml
    /// </summary>
    public partial class ProcesoSeleccionFinal : Page
    {
        ProcesoSeleccionCandidato window;

        ProcesoSeleccionInicio pInicio;
        ProcesoSeleccionDatos pDatos;
        ProcesoSeleccionFinal pFinal;
        public ProcesoSeleccionFinal()
        {
            InitializeComponent();
        }

        private void siguiente(object sender, RoutedEventArgs e)
        {
            if (pDatos.Salario.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos \nRegrese para verificar si queda algún campo vacío", "Advertencia");
            }
            else
            {
                using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                {
                    var dataCandi = db.Candidatos.Select(x => new { Id = x.Id, idPuesto = x.IdPuesto }).Where(x => x.Id == pInicio.idCandidato).FirstOrDefault();
                    var dataPuesto = db.Puestos.Where(x => x.Id == dataCandi.idPuesto).FirstOrDefault();
                    dataPuesto.Estado = 0;
                    db.Entry(dataPuesto).State = EntityState.Modified;
                    db.Empleados.Add(new Empleado() {
                        FechaIngreso = DateTime.Now,
                        Salario = Convert.ToDecimal(pDatos.Salario.Text),
                        Estado = 1,
                        IdCandidato = pInicio.idCandidato
                    });
                    db.SaveChanges();
                }
                window.pageConsulta.consultar(new System.Object(), new System.Windows.RoutedEventArgs());
                MessageBox.Show("El proceso de Seleccion de Candidato ha finalizado satisfactoriamente", "Aviso");
                window.Close();
            }
        }

        private void atras(object sender, RoutedEventArgs e)
        {
            pDatos.setObjects(window, pInicio, pDatos, this);
            window.Content = pDatos;
        }
        public void setObjects(ProcesoSeleccionCandidato window, ProcesoSeleccionInicio pInicio, ProcesoSeleccionDatos pDatos, ProcesoSeleccionFinal pFinal)
        {
            this.window = window;
            this.pInicio = pInicio;
            this.pDatos = pDatos;
            this.pFinal = pFinal;
        }
    }
}
