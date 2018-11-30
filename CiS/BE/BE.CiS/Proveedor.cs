using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BE.CiS
{
    [DataContract]
    public class Proveedor
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Mail { get; set; }
        [DataMember]
        public int IdCateProve { get; set; }
        [DataMember]
        public DateTime FechaCreacion { get; set; }
        [DataMember]
        public string CreadoPor { get; set; }
        [DataMember]
        public DateTime FechaActualizacion { get; set; }
        [DataMember]
        public string ActualizadoPor { get; set; }
        [DataMember]
        public int IsActive { get; set; }
    }
}
