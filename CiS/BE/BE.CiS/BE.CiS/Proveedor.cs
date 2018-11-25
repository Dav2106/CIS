using System;
using System.Collections.Generic;
using System.Text;

namespace BE.CiS
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public int IdCateProve { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string ActualizadoPor { get; set; }
        public int IsActive { get; set; }


    }
}
