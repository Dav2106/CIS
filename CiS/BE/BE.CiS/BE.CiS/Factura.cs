using System;
using System.Collections.Generic;
using System.Text;

namespace BE.CiS
{
    public class Factura
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public string Cliente { get; set; }
        public int IdDetaFact { get; set; }
        public string TipoPago { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string ActualizadoPor { get; set; }
    }
}
