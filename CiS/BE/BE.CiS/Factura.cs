using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BE.CiS
{
    [DataContract]
    public class Factura
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public double Total { get; set; }
        [DataMember]
        public string Cliente { get; set; }
        [DataMember]
        public int IdDetaFact { get; set; }
        [DataMember]
        public string TipoPago { get; set; }
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
