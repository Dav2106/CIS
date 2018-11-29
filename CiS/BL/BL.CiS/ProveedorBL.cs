using BE.CiS;
using DAC.CiS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.CiS
{
    public class ProveedorBL
    {
        ProveedorDAC proveedorDAC = new ProveedorDAC();

        public bool InsertarProveedor(Proveedor proveedor)
        {
            return proveedorDAC.InsertarProveedor(proveedor);
        }

        public bool ActualizarProveedor(Proveedor proveedor)
        {
            return proveedorDAC.ActualizarProveedor(proveedor);
        }

        public Proveedor GetProveedor(int id)
        {
            return proveedorDAC.GetProveedor(id);
        }

        public List<Proveedor> GetProveedores()
        {
            return proveedorDAC.GetProveedores();
        }
    }
}
