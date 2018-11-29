using BE.CiS;
using Logger.CiS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAC.CiS
{
    public class CategoriaProductoDAC
    {
        Conexion conn = new Conexion();
        ProjectLogger logs = new ProjectLogger();

        public bool InsertarCategoriaProducto(CategoriaProducto categoriaProducto)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "InsertCategoriaProducto";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_nombre", categoriaProducto.Nombre);
                    cmd.Parameters.AddWithValue("_descripcion", categoriaProducto.Descripcion);
                    cmd.Parameters.AddWithValue("_fechaCreacion", categoriaProducto.FechaCreacion);
                    cmd.Parameters.AddWithValue("_creadoPor", categoriaProducto.CreadoPor);
                    cmd.Parameters.AddWithValue("_fechaActualizacion", categoriaProducto.FechaActualizacion);
                    cmd.Parameters.AddWithValue("_actualizadoPor", categoriaProducto.ActualizadoPor);
                    cmd.Parameters.AddWithValue("_isActive", categoriaProducto.IsActive);
                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "InsertarCategoriaProducto", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "InsertarCategoriaProducto", UserSettings.User);
            }
            return flag;
        }

        public bool ActualizarCategoriaProducto(CategoriaProducto categoriaProducto)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "UpdateCategoriaProducto";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", categoriaProducto.Id);
                    cmd.Parameters.AddWithValue("_nombre", categoriaProducto.Nombre);
                    cmd.Parameters.AddWithValue("_descripcion", categoriaProducto.Descripcion);
                    cmd.Parameters.AddWithValue("_fechaActualizacion", categoriaProducto.FechaActualizacion);
                    cmd.Parameters.AddWithValue("_actualizadoPor", categoriaProducto.ActualizadoPor);
                    cmd.Parameters.AddWithValue("_isActive", categoriaProducto.IsActive);
                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "ActualizarCategoriaProducto", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "ActualizarCategoriaProducto", UserSettings.User);
            }
            return flag;
        }

        public CategoriaProducto GetCategoriaProducto(int id)
        {
            CategoriaProducto categoriaProducto = new CategoriaProducto();
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "GetCategoriaProducto";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            categoriaProducto.Id = Convert.ToInt16(reader["id"]);
                            categoriaProducto.Nombre = reader["nombre"].ToString();
                            categoriaProducto.Descripcion = reader["descripcion"].ToString();
                            categoriaProducto.IsActive = Convert.ToInt16(reader["isActive"]);                            
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "GetcategoriaProveedor", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "GetcategoriaProveedor", UserSettings.User);
            }
            return categoriaProducto;
        }

        public List<CategoriaProducto> GetCategoriasProducto()
        {
            List<CategoriaProducto> list = new List<CategoriaProducto>();
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "GetCategoriasProducto";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            list.Add(new CategoriaProducto
                            {
                                Id = Convert.ToInt16(reader["id"]),
                                Nombre = reader["nombre"].ToString(),
                                Descripcion = reader["descripcion"].ToString(),
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
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "GetCategoriasProducto", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "GetCategoriasProducto", UserSettings.User);
            }
            return list;
        }
    }
}
