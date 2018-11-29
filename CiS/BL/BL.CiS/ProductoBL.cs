using BE.CiS;
using DAC.CiS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.CiS
{
    public class ProductoBL
    {
        ProductoDAC productoDAC = new ProductoDAC();

        public bool InsertarProducto(Producto producto)
        {
            return productoDAC.InsertarProducto(producto);
        }

        public bool ActualizarProducto(Producto producto)
        {
            return productoDAC.ActualizarProducto(producto);
        }

        public Producto GetProducto(int id)
        {
            return productoDAC.GetProducto(id);
        }

        public List<Producto> GetProductos()
        {
            return productoDAC.GetProductos();
        }
    }
}
