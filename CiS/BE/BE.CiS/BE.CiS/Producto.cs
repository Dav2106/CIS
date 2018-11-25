using System;
using System.Collections.Generic;
using System.Text;

namespace BE.CiS
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public int IdCateProd { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string ActualizadoPor { get; set; }
        public int IsActive { get; set; }
        public int IdProveedor { get; set; }
    }
}
