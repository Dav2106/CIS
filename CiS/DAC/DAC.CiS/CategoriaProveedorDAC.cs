using BE.CiS;
using Logger.CiS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAC.CiS
{
    public class CategoriaProveedorDAC
    {
        Conexion conn = new Conexion();
        ProjectLogger logs = new ProjectLogger();

        public bool InsertarCategoriaProveedor(CategoriaProveedor categoriaProveedor)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "InsertCategoriaProveedor";
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
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "InsertarCategoriaProveedor", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "InsertarCategoriaProveedor", UserSettings.User);
            }
            return flag;
        }

        public bool ActualizarCategoriaProveedor(CategoriaProveedor categoriaProveedor)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "UpdateCategoriaProveedor";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", categoriaProveedor.Id);
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
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "ActualizarCategoriaProveedor", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "ActualizarCategoriaProveedor", UserSettings.User);
            }
            return flag;
        }

        public CategoriaProveedor GetCategoriaProveedor(int id)
        {
            CategoriaProveedor categoriaProveedor = new CategoriaProveedor();
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "GetCategoriaProveedor";
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
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "GetCategoriaProveedor", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "GetCategoriaProveedor", UserSettings.User);
            }
            return categoriaProveedor;
        }

        public List<CategoriaProveedor> GetCategoriasProveedor()
        {
            List<CategoriaProveedor> list = new List<CategoriaProveedor>();
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "GetCategoriasProveedor";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            list.Add(new CategoriaProveedor
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
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "GetCategoriasProveedor", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "GetCategoriasProveedor", UserSettings.User);
            }
            return list;
        }
    }
}
