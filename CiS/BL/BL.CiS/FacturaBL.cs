using BE.CiS;
using DAC.CiS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.CiS
{
    public class FacturaBL
    {
        FacturaDAC facturaDAC = new FacturaDAC();

        public bool InsertarUsuario(Factura factura)
        {
            return facturaDAC.InsertarFactura(factura);
        }

        public bool ActualizarUsuario(Factura factura)
        {
            return facturaDAC.ActualizarFactura(factura);
        }

        public Factura GetFactura(int id)
        {
            return facturaDAC.GetFactura(id);
        }

        public List<Factura> GetFacturas()
        {
            return facturaDAC.GetFacturas();
        }
    }
}
