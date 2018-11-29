using BE.CiS;
using DAC.CiS;
using System;
using System.Collections.Generic;

namespace BL.CiS
{
    public class CategoriaProductoBL
    {
        CategoriaProductoDAC categoriaProductoDAC = new CategoriaProductoDAC();

        public bool InsertarCategoriaProducto(CategoriaProducto categoriaProducto)
        {
            return categoriaProductoDAC.InsertarCategoriaProducto(categoriaProducto);
        }

        public bool ActualizarCategoriaProducto(CategoriaProducto categoriaProducto)
        {
            return categoriaProductoDAC.ActualizarCategoriaProducto(categoriaProducto);
        }

        public CategoriaProducto GetCategoriaProducto(int id)
        {
            return categoriaProductoDAC.GetCategoriaProducto(id);
        }

        public List<CategoriaProducto> GetCategoriasProducto()
        {
            return categoriaProductoDAC.GetCategoriasProducto();
        }
    }
}
