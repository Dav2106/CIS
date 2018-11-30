using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BE.CiS
{
    [DataContract]
    public class Cronograma
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime FechaRecibo { get; set; }
        [DataMember]
        public int IdProd { get; set; }
        [DataMember]
        public int IdProve { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public double Pago { get; set; }
        [DataMember]
        public int IsActive { get; set; }
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
