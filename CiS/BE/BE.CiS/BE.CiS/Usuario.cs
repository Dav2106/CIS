using System;
using System.Collections.Generic;
using System.Text;

namespace BE.CiS
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int IsAdmin{ get; set; }
        public int IsActive { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string ActualizadoPor { get; set; }
    }
}
