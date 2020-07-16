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

namespace ReclutamientoRH.Candidatos.Idiomas
{
    /// <summary>
    /// Lógica de interacción para Idiomas.xaml
    /// </summary>
    public partial class Idiomas : Page
    {
        public ViewModels.Candidato candidato;

        public Idiomas()
        {
            InitializeComponent();
        }
        public Idiomas(ViewModels.Candidato candidato)
        {
            InitializeComponent();
            this.candidato = candidato;
            listar();
        }

        private void listar()
        {
            List<IdiomaViewForm> idioma = new List<IdiomaViewForm>();
            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                var dbCandidatosSabenIdiomas = db.CandidatosSabenIdiomas.Where(x => x.IdCandidato == candidato.Id).ToList();
                var dbIdiomas = db.Idiomas.Where(x => x.Estado == 1).ToList();

                foreach (var item in dbIdiomas)
                {
                    bool existeIdioma = (dbCandidatosSabenIdiomas.Where(x => x.IdIdioma == item.Id).ToList().Count > 0) ? true : false;
                    if (existeIdioma)
                    {
                        idioma.Add(new IdiomaViewForm { isChecked = true, Id = item.Id, Nombre = item.Nombre });
                    }
                    else
                    {
                        idioma.Add(new IdiomaViewForm { isChecked = false, Id = item.Id, Nombre = item.Nombre });
                    }
                }
            }
            Tabla.ItemsSource = idioma;
        }

        private void casilla(object sender, RoutedEventArgs e)
        {
            int id = (int)((CheckBox)sender).CommandParameter;
            bool estaMarcado = (bool)((CheckBox)sender).IsChecked;
            if (!estaMarcado)
            {
                using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                {
                    var comp = db.CandidatosSabenIdiomas.Where(x => x.IdCandidato == candidato.Id).Where(x => x.IdIdioma == id).FirstOrDefault();
                    db.CandidatosSabenIdiomas.Remove(comp);
                    db.SaveChanges();
                }
            }
            if (estaMarcado)
            {
                using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                {
                    var comp = new CandidatosSabenIdioma() { IdCandidato = candidato.Id, IdIdioma = id };
                    db.CandidatosSabenIdiomas.Add(comp);
                    db.SaveChanges();
                }
            }
        }
    }
    class IdiomaViewForm : ViewModels.Idioma
    {
        public bool isChecked { get; set; }
    }
}
