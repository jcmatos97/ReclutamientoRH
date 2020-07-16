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

namespace ReclutamientoRH.Candidatos.Competencias
{
    /// <summary>
    /// Lógica de interacción para Competencias.xaml
    /// </summary>
    public partial class Competencias : Page
    {
        public ViewModels.Candidato candidato;

        public Competencias()
        {
            InitializeComponent();
        }
        public Competencias(ViewModels.Candidato candidato)
        {
            InitializeComponent();
            this.candidato = candidato;
            listar();
        }

        private void listar()
        {
            List<CompetenciaViewForm> competencia = new List<CompetenciaViewForm>();
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var dbCandidatosTienenCompetencias = db.CandidatosTienenCompetencias.Where(x => x.IdCandidato == candidato.Id).ToList();
                var dbCompetencias = db.Competencias.Where(x => x.Estado == 1).ToList();

                foreach (var item in dbCompetencias)
                {
                    bool existeCompetencia = (dbCandidatosTienenCompetencias.Where(x => x.IdCompetencia == item.Id).ToList().Count > 0) ? true : false;
                    if (existeCompetencia)
                    {
                        competencia.Add(new CompetenciaViewForm { isChecked=true, Id=item.Id, Nombre = item.Nombre});
                    }
                    else
                    {
                        competencia.Add(new CompetenciaViewForm { isChecked=false, Id=item.Id, Nombre = item.Nombre});
                    }
                }
            }
            Tabla.ItemsSource = competencia;
        }
        private void casilla(object sender, RoutedEventArgs e)
        {
            int id = (int)((CheckBox)sender).CommandParameter;
            bool estaMarcado = (bool)((CheckBox)sender).IsChecked;
            if (!estaMarcado)
            {
                using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                {
                    var comp = db.CandidatosTienenCompetencias.Where(x => x.IdCandidato == candidato.Id).Where(x => x.IdCompetencia == id).FirstOrDefault();
                    db.CandidatosTienenCompetencias.Remove(comp);
                    db.SaveChanges();
                }
            }
            if (estaMarcado)
            {
                using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                {
                    var comp = new CandidatosTienenCompetencia() {IdCandidato = candidato.Id, IdCompetencia = id };
                    db.CandidatosTienenCompetencias.Add(comp);
                    db.SaveChanges();
                }
            }
        }
    }
    class CompetenciaViewForm: ViewModels.Competencia
    {
        public bool isChecked { get; set; }
    }
}
