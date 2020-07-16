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
using System.Security.Cryptography;
using System.Data.Entity;

namespace ReclutamientoRH.Candidatos.DatosPersonales
{
    /// <summary>
    /// Lógica de interacción para EditarClaveFinal.xaml
    /// </summary>
    public partial class EditarClaveFinal : Page
    {
        ViewModels.Candidato candidato;
        editarClave windowEditarClave;
        public EditarClaveFinal()
        {
            InitializeComponent();
        }
        public EditarClaveFinal(ViewModels.Candidato candidato, editarClave windowEditarClave)
        {
            InitializeComponent();
            this.candidato = candidato;
            this.windowEditarClave = windowEditarClave;
        }

        private void guardar(object sender, RoutedEventArgs e)
        {
            bool isEmpty = ((clave.Password.ToString() == "") || (clave2.Password.ToString() == ""));
            bool isDifferent = (clave.Password.ToString() != clave2.Password.ToString());
            if(isEmpty || isDifferent)
            {
                MessageBox.Show("Hay campos vacíos o las contraseñas son diferentes \nFavor intentar de nuevo", "Información");
                clave.Password = "";
                clave2.Password = "";
            }
            else if (!(isEmpty || isDifferent))
            {
                Login.Login login = new Login.Login();
                string nuevaClave = login.GetMd5Hash(MD5.Create(), clave.Password.ToString());
                using(ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                {
                    var dbCandidato = db.Candidatos.Where(x => x.Id == candidato.Id).FirstOrDefault();
                    dbCandidato.Clave = nuevaClave;
                    db.Entry(dbCandidato).State = EntityState.Modified;
                    db.SaveChanges();
                }
                candidato.Clave = nuevaClave;
                login.Close();
                windowEditarClave.Close();
                MessageBox.Show("Esta información es personal." +
                    "\nPor su seguridad no debe suministrarla a nadie:"
                    + "\n"
                    + "\nUsuario: " + candidato.Usuario
                    + "\nClave: " + clave.Password.ToString()
                    + "\n"
                    + "\nEn caso de olvidar sus credenciales, comunicarse con los administradores del sistema.", "Datos de Usuario");
            }
        }

        private void cancelar(object sender, RoutedEventArgs e)
        {
            windowEditarClave.Close();
        }
    }
}
