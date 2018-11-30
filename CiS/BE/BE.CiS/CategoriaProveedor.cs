using System;
using System.Runtime.Serialization;

namespace BE.CiS
{
    [DataContract]
    public class CategoriaProveedor
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
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
