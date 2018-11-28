using BE.CiS;
using Logger.CiS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAC.CiS
{
    public class categoriaProveedorDAC
    {
        Conexion conn = new Conexion();
        ProjectLogger logs = new ProjectLogger();

        public bool InsertarcategoriaProveedor(categoriaProveedor categoriaProveedor)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "InsertcategoriaProveedor";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_nombre", categoriaProveedor.Nombre);
                    cmd.Parameters.AddWithValue("_descripcion", categoriaProveedor.Descripcion);
                    cmd.Parameters.AddWithValue("_fechaCreacion", categoriaProveedor.FechaCreacion);
                    cmd.Parameters.AddWithValue("_creadoPor", categoriaProveedor.CreadoPor);
                    cmd.Parameters.AddWithValue("_fechaActualizacion", categoriaProveedor.FechaActualizacion);
                    cmd.Parameters.AddWithValue("_actualizadoPor", categoriaProveedor.ActualizadoPor);
                    cmd.Parameters.AddWithValue("_isActive", categoriaProveedor.IsActive);
                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "InsertarcategoriaProveedor", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "InsertarcategoriaProveedor", UserSettings.User);
            }
            return flag;
        }

        public bool ActualizarcategoriaProveedor(categoriaProveedor categoriaProveedor)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "UpdatecategoriaProveedor";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", categoriaProveedor.Id);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_nombre", categoriaProveedor.Nombre);
                    cmd.Parameters.AddWithValue("_descripcion", categoriaProveedor.Descripcion);
                    cmd.Parameters.AddWithValue("_fechaActualizacion", categoriaProveedor.FechaActualizacion);
                    cmd.Parameters.AddWithValue("_actualizadoPor", categoriaProveedor.ActualizadoPor);
                    cmd.Parameters.AddWithValue("_isActive", categoriaProveedor.IsActive);
                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "ActualizarcategoriaProveedor", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "ActualizarcategoriaProveedor", UserSettings.User);
            }
            return flag;
        }

        public categoriaProveedor GetcategoriaProveedor(int id)
        {
            categoriaProveedor categoriaProveedor = new categoriaProveedor();
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "GetcategoriaProveedor";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            categoriaProveedor.Id = Convert.ToInt16(reader["id"]);
                            categoriaProveedor.Nombre = reader["nombre"].ToString();
                            categoriaProveedor.Descripcion = reader["descripcion"].ToString();
                            categoriaProveedor.IsActive = Convert.ToInt16(reader["isActive"]);                            
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
            return categoriaProveedor;
        }

        public List<categoriaProveedor> GetCategoriasProducto()
        {
            List<categoriaProveedor> list = new List<categoriaProveedor>();
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
                            list.Add(new categoriaProveedor
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
