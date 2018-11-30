using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BE.CiS
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int IsAdmin{ get; set; }
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
