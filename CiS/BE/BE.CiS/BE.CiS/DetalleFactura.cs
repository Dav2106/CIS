using System;
using System.Collections.Generic;
using System.Text;

namespace BE.CiS
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int Transaccion { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string ActualizadoPor { get; set; }
    }
}
