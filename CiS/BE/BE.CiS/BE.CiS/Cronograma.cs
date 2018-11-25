using System;
using System.Collections.Generic;
using System.Text;

namespace BE.CiS
{
    public class Cronograma
    {
        public int Id { get; set; }
        public DateTime FechaRecibo { get; set; }
        public int IdProd { get; set; }
        public int IdProve { get; set; }
        public int Cantidad { get; set; }
        public float Pago { get; set; }
        public int IsActive { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string ActualizadoPor { get; set; }
    }
}
