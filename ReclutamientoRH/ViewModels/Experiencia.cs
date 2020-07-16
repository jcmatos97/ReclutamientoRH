using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoRH.ViewModels
{
    public class Experiencia
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Puesto { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta{ get; set; }
        public decimal Salario { get; set; }
        public int IdCandidato { get; set; }
    }
}
