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
using System.Windows.Shapes;
using ReclutamientoRH.ViewModels;
using System.Data.Entity;
using ReclutamientoRH.DataContext;

namespace ReclutamientoRH.Candidatos.DatosVacante
{
    /// <summary>
    /// Lógica de interacción para editarDatosVacante.xaml
    /// </summary>
    public partial class editarDatosVacante : Window
    {
        ViewModels.Candidato candidato;
        DatosVacante pageDatosVacante;
        public editarDatosVacante()
        {
            InitializeComponent();
        }
        public editarDatosVacante(ViewModels.Candidato candidato, DatosVacante pageDatosVacante)
        {
            InitializeComponent();
            this.candidato = candidato;
            this.pageDatosVacante = pageDatosVacante;
            recomendadopor.Text = candidato.RecomendadoPor;
            aspiracion.Text = candidato.SalarioAspiracion.ToString();
        }

        private void editar(object sender, RoutedEventArgs e)
        {
            bool isEmpty = ((recomendadopor.Text == "") || (aspiracion.Text == ""));
            if (isEmpty)
            {
                MessageBox.Show("Hay campos vacíos \nFavor intentar de nuevo", "Información");
            }
            else if (!isEmpty)
            {
                using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                {
                    var dbCandidato = db.Candidatos.Where(x => x.Id == candidato.Id).FirstOrDefault();
                    dbCandidato.RecomendadoPor = recomendadopor.Text;
                    dbCandidato.SalarioAspiracion = Convert.ToDecimal(aspiracion.Text);
                    db.Entry(dbCandidato).State = EntityState.Modified;
                    db.SaveChanges();
                    candidato.RecomendadoPor = recomendadopor.Text;
                    candidato.SalarioAspiracion = Convert.ToDecimal(aspiracion.Text);
                }
                pageDatosVacante.listar();
                Close();
            }
        }

        private void cancelar(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
