using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BE.CiS
{
    [DataContract]
    public class DetalleFactura
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Transaccion { get; set; }
        [DataMember]
        public int IdProducto { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public DateTime FechaCreacion { get; set; }
        [DataMember]
        public string CreadoPor { get; set; }
        [DataMember]
        public DateTime FechaActualizacion { get; set; }
        [DataMember]
        public string ActualizadoPor { get; set; }
    }
}
