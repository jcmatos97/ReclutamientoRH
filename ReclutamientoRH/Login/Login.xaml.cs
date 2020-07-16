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
using ReclutamientoRH.Registro;
using System.Security.Cryptography;
using ReclutamientoRH.DataContext;
using ReclutamientoRH.ViewModels;
using ReclutamientoRH.Candidatos;
using System.Data.Entity;

namespace ReclutamientoRH.Login
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        //Boton Login
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string this_user = "admin";
            string this_pass = "12345";

            string usuario = user.Text;
            string clave = GetMd5Hash(MD5.Create(), pass.Password.ToString());

            ViewModels.Candidato candi;
            DataContext.Candidato dbcandi;

            using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
            {
                dbcandi = db.Candidatos.Where(x => (x.Usuario == usuario)&&(x.Clave == clave)).Include(x => x.Puesto).FirstOrDefault();     
            }

            if (user.Text == this_user && pass.Password.ToString() == this_pass)
            {
                MainWindow mw = new MainWindow();
                Close();
                mw.Show();
            }
            else if (dbcandi != null)
            {
                DataContext.Empleado dataEmpleado;
                bool esEmpleado;
                using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                {
                    dataEmpleado = db.Empleados.Where(x => x.IdCandidato == dbcandi.Id).FirstOrDefault();
                    esEmpleado = dataEmpleado != null ? true : false;
                }
                if (esEmpleado)
                {
                    user.Text = "";
                    pass.Password = "";
                    MessageBox.Show("Usted fue seleccionado como empleado el: " + dataEmpleado.FechaIngreso.ToShortDateString()+"\nLa vacante ocupada fue: "
                        +dbcandi.Puesto.Nombre+" - "+dbcandi.Puesto.Departamento, "Advertencia");
                }
                else if (!esEmpleado)
                {
                    candi = new ViewModels.Candidato() 
                    {
                        Id = dbcandi.Id,
                        Nombre = dbcandi.Nombre,
                        Cedula = dbcandi.Cedula,
                        Usuario = dbcandi.Usuario,
                        Clave = dbcandi.Clave,
                        SalarioAspiracion = Convert.ToDecimal(dbcandi.SalarioAspiracion),
                        RecomendadoPor = dbcandi.RecomendadoPor,
                        IdPuesto = dbcandi.IdPuesto
                    };
                    MainWindowCandidato cmw = new MainWindowCandidato(candi);
                    Close();
                    cmw.Show();
                }
                                
            }
            else
            {
                user.Text = "";
                pass.Password = "";
                MessageBox.Show("Acceso Denegado \nVerifica tus credenciales e intenta de nuevo", "Alerta");
            }
        }
        //Boton Registrarse
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registro.Registro rw = new Registro.Registro();
            Close();
            rw.Show();
        }

        public string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        private bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
