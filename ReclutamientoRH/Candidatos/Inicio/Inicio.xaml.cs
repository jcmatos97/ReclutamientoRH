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

namespace ReclutamientoRH.Candidatos.Inicio
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Page
    {
        public Candidato candidato;
        public Inicio()
        {
            InitializeComponent();
        }
        public Inicio(Candidato candidato)
        {
            InitializeComponent();
            this.candidato = candidato;
            BienvenidoText.Content = "¡Bienvenido " + candidato.Nombre + "!";
        }
    }
}
