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
using System.Security.Cryptography;
using ReclutamientoRH.DataContext;
using ReclutamientoRH.Login;
using ReclutamientoRH.Helpers;

namespace ReclutamientoRH.Registro
{
    /// <summary>
    /// Lógica de interacción para RegistroFinal.xaml
    /// </summary>
    public partial class RegistroFinal : Page
    {
        Registro mainWindow;
        RegistroInicio pageInicio;
        RegistroDatosPersonales pageDatosPersonales;
        RegistroPuesto pagePuesto;
        RegistroFinal pageFinal;

        //Id de Puesto
        int idPuesto;
        public RegistroFinal()
        {
            InitializeComponent();
        }
        private void atras(object sender, RoutedEventArgs e)
        {
            pagePuesto.setObjetcs(mainWindow, pageInicio, pageDatosPersonales, pagePuesto, this);
            mainWindow.Content = pagePuesto;
        }

        private void siguiente(object sender, RoutedEventArgs e)
        {
            bool isEmpty = ((pageDatosPersonales.Nombre.Text == "") || (pageDatosPersonales.Apellido.Text == "") || (pageDatosPersonales.Cedula.Text == "")
                || (pageDatosPersonales.Usuario.Text == "") || (pageDatosPersonales.Clave1.Password.ToString() == "") || (pageDatosPersonales.Clave2.Password.ToString() == "")
                || (idPuesto < 1) || (pagePuesto.SalarioAspiracion.Text == "") || (pagePuesto.RecomendadoPor.Text == ""));
            bool keysAreDifferent = (pageDatosPersonales.Clave1.Password.ToString() != pageDatosPersonales.Clave2.Password.ToString());
            //bool isCedulaValida = Cedula.isCedulaValida(pageDatosPersonales.Cedula.Text);
            bool isCedulaValida = true;

            if (isEmpty && keysAreDifferent && !isCedulaValida)
            {
                MessageBox.Show("Debe completar todos los campos \nLas contraseñas colocadas no coinciden \nLa Cedula No es Valida", "Advertencia");
            }
            else if (isEmpty && keysAreDifferent && isCedulaValida)
            {
                MessageBox.Show("Debe completar todos los campos \nLas contraseñas colocadas no coinciden", "Advertencia");
            }
            else if (isEmpty && !keysAreDifferent && !isCedulaValida)
            {
                MessageBox.Show("Debe completar todos los campos \nLa Cedula No es Valida", "Advertencia");
            }
            else if (isEmpty && !keysAreDifferent && isCedulaValida)
            {
                MessageBox.Show("Debe completar todos los campos", "Advertencia");
            }
            else if (!isEmpty && keysAreDifferent && !isCedulaValida)
            {
                MessageBox.Show("Las contraseñas colocadas no coinciden \nLa Cedula No es Valida", "Advertencia");
            }
            else if (!isEmpty && keysAreDifferent && isCedulaValida)
            {
                MessageBox.Show("Las contraseñas colocadas no coinciden", "Advertencia");
            }
            else if (!isEmpty && !keysAreDifferent && !isCedulaValida)
            {
                MessageBox.Show("La Cedula No es Valida", "Advertencia");
            }
            else if(!isEmpty && !keysAreDifferent && isCedulaValida)
            { 
                ViewModels.Candidato candidato = new ViewModels.Candidato()
                {
                    Nombre = pageDatosPersonales.Nombre.Text + " " + pageDatosPersonales.Apellido.Text,
                    Cedula = pageDatosPersonales.Cedula.Text,
                    Usuario = pageDatosPersonales.Usuario.Text,
                    Clave = GetMd5Hash(MD5.Create(), pageDatosPersonales.Clave1.Password.ToString()),
                    IdPuesto = idPuesto,
                    SalarioAspiracion = Convert.ToDecimal(pagePuesto.SalarioAspiracion.Text),
                    RecomendadoPor = pagePuesto.RecomendadoPor.Text
                };

           
                using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                {
                    db.Candidatos.Add(new Candidato() { 
                        Nombre = candidato.Nombre,
                        Cedula = candidato.Cedula,
                        Usuario = candidato.Usuario,
                        Clave = candidato.Clave,
                        IdPuesto = idPuesto,
                        SalarioAspiracion = candidato.SalarioAspiracion,
                        RecomendadoPor = candidato.RecomendadoPor
                    });
                    db.SaveChanges();
                }

                MessageBox.Show("Esta información es personal."+
                    "\nPor su seguridad no debe suministrarla a nadie:"
                    +"\n"
                    +"\nUsuario: " + candidato.Usuario
                    + "\nClave: " + pageDatosPersonales.Clave1.Password.ToString()
                    +"\n"
                    +"\nEn caso de olvidar sus credenciales, comunicarse con los administradores del sistema.", "Datos de Usuario");

                Login.Login login = new Login.Login();
                login.Show();
            
            mainWindow.Close();
            }
            
        }

        public void setObjetcs(Registro mainWindow, RegistroInicio pageInicio, RegistroDatosPersonales pageDatosPersonales, RegistroPuesto pagePuesto, RegistroFinal pageFinal)
        {
            this.mainWindow = mainWindow;
            this.pageInicio = pageInicio;
            this.pageDatosPersonales = pageDatosPersonales;
            this.pagePuesto = pagePuesto;
            this.pageFinal = pageFinal;
        }
        public void setIdPuesto(int id)
        {
            idPuesto = id;
        }

        private string GetMd5Hash(MD5 md5Hash, string input)
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

        /*
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
        */
    }
}
