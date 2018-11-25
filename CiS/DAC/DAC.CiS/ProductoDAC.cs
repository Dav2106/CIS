using BE.CiS;
using Logger.CiS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAC.CiS
{
    public class ProductoDAC
    {
        Conexion conn = new Conexion();
        ProjectLogger logs = new ProjectLogger();

        public bool InsertarProducto(Producto producto)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "InsertProducto";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("_descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("_precio", producto.Precio);
                    cmd.Parameters.AddWithValue("_stock", producto.Stock);
                    cmd.Parameters.AddWithValue("_idProve", producto.IdProveedor);
                    cmd.Parameters.AddWithValue("_idCateProd", producto.IdCateProd);
                    cmd.Parameters.AddWithValue("_fechaCreacion", producto.FechaCreacion);
                    cmd.Parameters.AddWithValue("_creadoPor", producto.CreadoPor);
                    cmd.Parameters.AddWithValue("_fechaActualizacion", producto.FechaActualizacion);
                    cmd.Parameters.AddWithValue("_actualizadoPor", producto.ActualizadoPor);
                    cmd.Parameters.AddWithValue("_isActive", producto.IsActive);
                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "InsertarProducto", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "InsertarProducto", UserSettings.User);
            }
            return flag;
        }

        public bool ActualizarProducto(Producto producto)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "UpdateProducto";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", producto.Id);
                    cmd.Parameters.AddWithValue("_nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("_descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("_precio", producto.Precio);
                    cmd.Parameters.AddWithValue("_stock", producto.Stock);
                    cmd.Parameters.AddWithValue("_idProve", producto.IdProveedor);
                    cmd.Parameters.AddWithValue("_idCateProd", producto.IdCateProd);
                    cmd.Parameters.AddWithValue("_fechaActualizacion", producto.FechaActualizacion);
                    cmd.Parameters.AddWithValue("_actualizadoPor", producto.ActualizadoPor);
                    cmd.Parameters.AddWithValue("_isActive", producto.IsActive);
                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "ActualizarProducto", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "ActualizarProducto", UserSettings.User);
            }
            return flag;
        }

        public Producto GetProducto(int id)
        {
            Producto producto = new Producto();
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "GetProducto";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            producto.Id = Convert.ToInt16(reader["id"]);
                            producto.Nombre = reader["nombre"].ToString();
                            producto.Descripcion = reader["descripcion"].ToString();
                            producto.Precio = Convert.ToDouble(reader["precio"]);
                            producto.Stock = Convert.ToInt16(reader["stock"]);
                            producto.IdProveedor = Convert.ToInt16(reader["idProve"]);
                            producto.IdCateProd = Convert.ToInt16(reader["idCateProd"]);
                            producto.IsActive = Convert.ToInt16(reader["isActive"]);
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "GetProducto", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "GetProducto", UserSettings.User);
            }
            return producto;
        }

        public List<Producto> GetProductos()
        {
            List<Producto> list = new List<Producto>();
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "GetProductos";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            list.Add(new Producto
                            {
                                Id = Convert.ToInt16(reader["id"]),
                                Nombre = reader["nombre"].ToString(),
                                Descripcion = reader["descripcion"].ToString(),
                                Precio = Convert.ToDouble(reader["precio"]),
                                Stock = Convert.ToInt16(reader["stock"]),
                                IdProveedor = Convert.ToInt16(reader["idProve"]),
                                IdCateProd = Convert.ToInt16(reader["idCateProd"]),
                                IsActive = Convert.ToInt16(reader["isActive"]),
                                FechaCreacion = Convert.ToDateTime(reader["fechaCreacion"]),
                                CreadoPor = reader["creadoPor"].ToString(),
                                FechaActualizacion = Convert.ToDateTime(reader["fechaActualizacion"]),
                                ActualizadoPor = reader["actualizadoPor"].ToString()
                            });
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "GetProductos", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "GetProductos", UserSettings.User);
            }
            return list;
        }
    }
}
