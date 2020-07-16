using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoRH.ViewModels
{
    public class Puesto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public string NivelDeRiesgo { get; set; }
        public decimal NivelMinSalario { get; set; }
        public decimal NivelMaxSalario { get; set; }
        public int Estado { get; set; }

    }
}
