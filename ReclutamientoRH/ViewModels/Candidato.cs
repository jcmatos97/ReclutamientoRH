using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoRH.ViewModels
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre{ get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public decimal SalarioAspiracion { get; set; }
        public string RecomendadoPor { get; set; }
        public int IdPuesto { get; set; }
    }
}
