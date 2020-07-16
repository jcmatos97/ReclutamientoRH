using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoRH.ViewModels
{
    public class Capacitaciones
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nivel { get; set; }
        public string FechaDesde{ get; set; }
        public string FechaHasta { get; set; }
        public string Institucion { get; set; }
        public int IdCandidato { get; set; }
    }
}
