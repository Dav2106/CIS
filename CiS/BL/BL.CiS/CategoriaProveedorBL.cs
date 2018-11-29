using BE.CiS;
using DAC.CiS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.CiS
{
    public class CategoriaProveedorBL
    {
        CategoriaProveedorDAC categoriaProveedorDAC = new CategoriaProveedorDAC();

        public bool InsertarCategoriaProveedor(CategoriaProveedor categoriaProveedor)
        {
            return categoriaProveedorDAC.InsertarCategoriaProveedor(categoriaProveedor);
        }

        public bool ActualizarCategoriaProveedor(CategoriaProveedor categoriaProveedor)
        {
            return categoriaProveedorDAC.ActualizarCategoriaProveedor(categoriaProveedor);
        }

        public CategoriaProveedor GetCategoriaProveedor(int id)
        {
            return categoriaProveedorDAC.GetCategoriaProveedor(id);
        }

        public List<CategoriaProveedor> GetCategoriaProveedor()
        {
            return categoriaProveedorDAC.GetCategoriasProveedor();
        }
    }
}
