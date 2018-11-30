using BE.CiS;
using DAC.CiS;
using Logger.CiS;
using System;
using System.Collections.Generic;

namespace BL.CiS
{
    public class CategoriaProductoBL
    {
        CategoriaProductoDAC categoriaProductoDAC = new CategoriaProductoDAC();
        ProjectLogger logs = new ProjectLogger();

        public bool InsertarCategoriaProducto(CategoriaProducto categoriaProducto)
        {
            bool flag = false;
            try
            {
                flag = categoriaProductoDAC.InsertarCategoriaProducto(categoriaProducto);
            }
            catch (Exception ex)
            {
                logs.LogException(ex, "InsertarCategoriaProducto", UserSettings.User);
            }
            return flag;
        }

        public bool ActualizarCategoriaProducto(CategoriaProducto categoriaProducto)
        {
            bool flag = false;
            try
            {
                flag = categoriaProductoDAC.ActualizarCategoriaProducto(categoriaProducto);
            }
            catch (Exception ex)
            {
                logs.LogException(ex, "ActualizarCategoriaProducto", UserSettings.User);
            }
            return flag;
        }

        public CategoriaProducto GetCategoriaProducto(int id)
        {
            CategoriaProducto catProd = new CategoriaProducto();
            try
            {
                catProd = categoriaProductoDAC.GetCategoriaProducto(id);
            }
            catch(Exception ex)
            {
                logs.LogException(ex, "GetCategoriaProducto", UserSettings.User);
            }
            return catProd;
        }

        public List<CategoriaProducto> GetCategoriasProducto()
        {
            List<CategoriaProducto> list = new List<CategoriaProducto>();
            try
            {
                list = categoriaProductoDAC.GetCategoriasProducto();
            }
            catch (Exception ex)
            {
                logs.LogException(ex, "GetCategoriasProducto", UserSettings.User);
            }
            return list;
        }
    }
}
