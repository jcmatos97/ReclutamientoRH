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
using ReclutamientoRH.RecursosHumanos.ProcesoSeleccion;
using ReclutamientoRH.ViewModels;
using ReclutamientoRH.DataContext;
using System.Text.RegularExpressions;

namespace ReclutamientoRH.RecursosHumanos.ConsultaCandidatos
{
    /// <summary>
    /// Lógica de interacción para ConsultaCandidatos.xaml
    /// </summary>
    public partial class ConsultaCandidatos : Page
    {
        public ConsultaCandidatos()
        {
            InitializeComponent();
        }

        public void consultar(object sender, RoutedEventArgs e)
        {
            bool nombre = (Nombre.Text == "") ? false : true;
            bool cedula = (Cedula.Text == "") ? false : true;
            bool usuario = (Usuario.Text == "") ? false : true;
            bool puesto = (Puesto.Text == "") ? false : true;
            bool salarioDesde = (SalarioDesde.Text == "") ? false : true;
            bool salarioHasta = (SalarioHasta.Text == "") ? false : true;
            bool recomendadoPor = (RecomendadoPor.Text == "") ? false : true;

            IQueryable<DataContext.Candidato> queryCandidato;
            
            List<CandidatosViewModel> data = new List<CandidatosViewModel>();
            
            decimal DesdeSalario;
            decimal HastaSalario;
            try
            {
                DesdeSalario = Convert.ToDecimal(SalarioDesde.Text);
            }
            catch (FormatException)
            {
                DesdeSalario = 0;
            }            
            try
            {
                HastaSalario = Convert.ToDecimal(SalarioHasta.Text);
            }
            catch (FormatException)
            {
                HastaSalario = 0;
            }

            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                queryCandidato = db.Set<DataContext.Candidato>();
                
                if (nombre)
                    queryCandidato = queryCandidato.Where(t => (t.Nombre.Contains(Nombre.Text)));
                if (cedula)
                    queryCandidato = queryCandidato.Where(t => (t.Cedula.Contains(Cedula.Text)));
                if (usuario)
                    queryCandidato = queryCandidato.Where(t => (t.Usuario.Contains(Usuario.Text)));
                if (puesto)
                    queryCandidato = queryCandidato.Where(t => (t.Puesto.Nombre.Contains(Puesto.Text)));
                if (salarioDesde)
                    queryCandidato = queryCandidato.Where(t => (t.SalarioAspiracion >= DesdeSalario));
                if (salarioHasta)
                    queryCandidato = queryCandidato.Where(t => (t.SalarioAspiracion <= HastaSalario));
                if (recomendadoPor)
                    queryCandidato = queryCandidato.Where(t => (t.RecomendadoPor.Contains(RecomendadoPor.Text)));
                if(!(nombre||cedula||usuario || puesto || salarioDesde || salarioHasta || recomendadoPor))
                    queryCandidato = queryCandidato;
            

                foreach (var item in queryCandidato.ToList())
                {
                    int candidatosEnPuestosValidos = db.Puestos.Where(x => (x.Id == item.IdPuesto) && (x.Estado == 0)).Count();
                    if(candidatosEnPuestosValidos == 0)
                    {
                        data.Add(new CandidatosViewModel()
                        { 
                            Id = item.Id,
                            Nombre = item.Nombre,
                            Cedula = item.Cedula,
                            Usuario = item.Usuario,
                            Puesto = item.Puesto.Nombre,
                            SalarioAspiracion = (decimal)item.SalarioAspiracion,
                            RecomendadoPor = item.RecomendadoPor
                        });
                    }
                    else
                    {
                        //Do nothing
                    }
                }

                Tabla.ItemsSource = data.ToList();
            }

        }

        private void limpiarCampos(object sender, RoutedEventArgs e)
        {
            Nombre.Text = "";
            Cedula.Text = "";
            Usuario.Text = "";
            Puesto.Text = "";
            SalarioDesde.Text = "";
            SalarioHasta.Text = "";
            RecomendadoPor.Text = "";
        }

        private void detalle(object sender, RoutedEventArgs e)
        {
            int idCandidato = Convert.ToInt32(((Button)sender).CommandParameter.ToString());
            DetalleCandidato detalleCandidato = new DetalleCandidato(idCandidato);
            detalleCandidato.Show();
        }

        private void seleccionarCandidato(object sender, RoutedEventArgs e)
        {
            int idCandidato = Convert.ToInt32(((Button)sender).CommandParameter.ToString());
            System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("¿Desea iniciar el Proceso de Selección del Candidato?", "Advetencia", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                //do something
                ProcesoSeleccionCandidato procesoCand = new ProcesoSeleccionCandidato(idCandidato, this);
                procesoCand.Show();
            }
            else if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                //do something else
            }
        }

        private void filtroSoloNumeros(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
    public class CandidatosViewModel : ViewModels.Candidato
    {
        public string Puesto { get; set; }
        public string  Idiomas { get; set; }
        public string Competencias { get; set; }
        public List<ViewModels.Capacitaciones> Capacitaciones { get; set; }
        public List<ViewModels.Experiencia> Experiencias { get; set; }
    }
}
