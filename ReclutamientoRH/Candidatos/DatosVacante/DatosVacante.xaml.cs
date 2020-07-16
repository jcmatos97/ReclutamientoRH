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

namespace ReclutamientoRH.Candidatos.DatosVacante
{
    /// <summary>
    /// Lógica de interacción para DatosVacante.xaml
    /// </summary>
    public partial class DatosVacante : Page
    {
        ViewModels.Candidato candidato;
        public DatosVacante()
        {
            InitializeComponent();
        }        
        public DatosVacante(ViewModels.Candidato candidato)
        {
            InitializeComponent();
            this.candidato = candidato;
            listar();
        }

        private void editar(object sender, RoutedEventArgs e)
        {
            editarDatosVacante windowEditVacante = new editarDatosVacante(candidato, this);
            windowEditVacante.Show();
        }

        private void getPuesto(object sender, RoutedEventArgs e)
        {
            int idPuesto = (int)(((RadioButton)sender).CommandParameter);
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var dbCandidato = db.Candidatos.Where(x => x.Id == candidato.Id).FirstOrDefault();
                dbCandidato.IdPuesto = idPuesto;
                db.Entry(dbCandidato).State = EntityState.Modified;
                db.SaveChanges();
                candidato.IdPuesto = idPuesto;
            }
        }
        public void listar()
        {
            RecomendadoPor.Text = candidato.RecomendadoPor;
            SalarioAspiracion.Text = candidato.SalarioAspiracion.ToString();

            List<PuestosViewForm> puestos = new List<PuestosViewForm>();

            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var dbPuestos = db.Puestos.Where(x => x.Estado == 1).ToList();

                foreach (var item in dbPuestos)
                {
                    bool existePuesto = (db.Candidatos.Where(x => x.Id == candidato.Id).Where(x => x.IdPuesto == item.Id).ToList().Count > 0) ? true : false;
                    if (existePuesto)
                    {
                        puestos.Add(new PuestosViewForm 
                        {
                            isChecked = true,
                            Id = item.Id,
                            Nombre = item.Nombre,
                            Departamento = item.Departamento,
                            NivelDeRiesgo = item.NivelDeRiesgo,
                            NivelMaxSalario = (decimal)item.NivelMaxSalario,
                            NivelMinSalario = (decimal)item.NivelMinSalario,
                            Estado = item.Estado
                        });
                    }
                    else
                    {
                        puestos.Add(new PuestosViewForm
                        {
                            isChecked = false,
                            Id = item.Id,
                            Nombre = item.Nombre,
                            Departamento = item.Departamento,
                            NivelDeRiesgo = item.NivelDeRiesgo,
                            NivelMaxSalario = (decimal)item.NivelMaxSalario,
                            NivelMinSalario = (decimal)item.NivelMinSalario,
                            Estado = item.Estado
                        });

                    }
                }
            }
            Tabla.ItemsSource = puestos;
        }
    }
    class PuestosViewForm : ViewModels.Puesto
    {
        public bool isChecked { get; set; }
    }
}
