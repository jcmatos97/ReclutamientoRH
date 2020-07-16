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
using ReclutamientoRH.DataContext;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace ReclutamientoRH.RecursosHumanos.Puestos
{
    /// <summary>
    /// Lógica de interacción para puestosAddUpdate.xaml
    /// </summary>
    public partial class puestosAddUpdate : Window
    {
        ViewModels.Puesto modelPuesto;
        Puestos pagePuesto;

        public puestosAddUpdate(Puestos pagePuesto)
        {
            InitializeComponent();
            Title = "Agregar Puesto de Trabajo";
            Info.Content = "Crear una vacante de un puesto:";
            AgregarActualizar.Content = "Agregar";
            this.pagePuesto = pagePuesto;
        }

        public puestosAddUpdate(ViewModels.Puesto modelPuesto, Puestos pagePuesto)
        {
            InitializeComponent();
            Title = "Editar Puesto de Trabajo";
            Info.Content = "Editar una vacante de un puesto:";
            AgregarActualizar.Content = "Editar";
            Nombre.Text = modelPuesto.Nombre;
            Departamento.Text = modelPuesto.Departamento;
            NivelDeRiesgo.SelectedIndex = obtenerIndiceNivelRiesgo(modelPuesto.NivelDeRiesgo);
            NivelMinSalario.Text = modelPuesto.NivelMinSalario.ToString();
            NivelMaxSalario.Text = modelPuesto.NivelMaxSalario.ToString();
            this.pagePuesto = pagePuesto;
            this.modelPuesto = modelPuesto;
        }

        private void agregarActualizar(object sender, RoutedEventArgs e)
        {
            if (modelPuesto == null)
            {
                if ((Nombre.Text == "") || (Departamento.Text == "") || (NivelDeRiesgo.Text == "") || (NivelMinSalario.Text == "") || (NivelMaxSalario.Text == ""))
                {
                    MessageBox.Show("Debe completar todos los campos", "Advertencia");
                }
                if (
                    (Convert.ToDouble(NivelMinSalario.Text)< 0)
                    || (Convert.ToDouble(NivelMaxSalario.Text) < 0)
                    || (Convert.ToDouble(NivelMinSalario.Text) > Convert.ToDouble(NivelMaxSalario.Text))
                    )
                {
                    MessageBox.Show("El Salario minimo no puede ser mayor que el Salario Maximo \nO los salarios no pueden ser negativos \nFavor verificar", "Advertencia");
                }
                else
                {
                    using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                    {
                        var dataPuesto = new DataContext.Puesto()
                        {
                            Nombre = Nombre.Text,
                            Departamento = Departamento.Text,
                            NivelDeRiesgo = NivelDeRiesgo.Text,
                            NivelMinSalario = Convert.ToDecimal(NivelMinSalario.Text),
                            NivelMaxSalario = Convert.ToDecimal(NivelMaxSalario.Text),
                            Estado = 1
                        };
                        db.Puestos.Add(dataPuesto);
                        db.SaveChanges();
                    }
                    pagePuesto.Listar();
                    Close();
                }
            }
            if (modelPuesto != null)
            {
                if ((Nombre.Text == "") || (Departamento.Text == "") || (NivelDeRiesgo.Text == "") || (NivelMinSalario.Text == "") || (NivelMaxSalario.Text == ""))
                {
                    MessageBox.Show("Debe completar todos los campos", "Advertencia");
                }
                else
                { 
                    using (ReclutamientoRHEntities db = new ReclutamientoRHEntities())
                    {
                        var dataPuesto = db.Puestos.Where(x => x.Id == this.modelPuesto.Id).FirstOrDefault();
                        dataPuesto.Nombre = Nombre.Text;
                        dataPuesto.Departamento = Departamento.Text;
                        dataPuesto.NivelDeRiesgo = NivelDeRiesgo.Text;
                        dataPuesto.NivelMinSalario = Convert.ToDecimal(NivelMinSalario.Text);
                        dataPuesto.NivelMaxSalario = Convert.ToDecimal(NivelMaxSalario.Text);
                        db.Entry(dataPuesto).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    pagePuesto.Listar();
                    Close();
                }
            }
            
        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Indices Nivel Riesgo
        enum NivelDeRiesgoIndex
        {
            Default = -1,
            Bajo = 0,
            Medio = 1,
            Alto = 2
        }

        //Obtener indice del Nivel de Riesgo
        public int obtenerIndiceNivelRiesgo(string str)
        {
            int index = (int)NivelDeRiesgoIndex.Default;
            switch (str)
            {
                case "Bajo":
                    index = (int)NivelDeRiesgoIndex.Bajo;
                    break;
                case "Medio":
                    index = (int)NivelDeRiesgoIndex.Medio;  
                    break;
                case "Alto":
                    index = (int)NivelDeRiesgoIndex.Alto;
                    break;
                default:
                    index = (int)NivelDeRiesgoIndex.Default;
                    break;
            }
            return index;
        }

    }
}
