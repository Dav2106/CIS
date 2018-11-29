using BE.CiS;
using DAC.CiS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.CiS
{
    public class DetalleFacturaBL
    {
        DetalleFacturaDAC detalleFacturaDAC = new DetalleFacturaDAC();

        public bool InsertarDetalleFactura(DetalleFactura detalleFactura)
        {
            return detalleFacturaDAC.InsertarDetalleFactura(detalleFactura);
        }

        public bool ActualizarDetalleFactura(DetalleFactura detalleFactura)
        {
            return detalleFacturaDAC.ActualizarDetalleFactura(detalleFactura);
        }

        public DetalleFactura GetDetalleFactura(int id)
        {
            return detalleFacturaDAC.GetDetalleFactura(id);
        }

        public List<DetalleFactura> GetDetallesFactura()
        {
            return detalleFacturaDAC.GetDetallesFactura();
        }
    }
}
