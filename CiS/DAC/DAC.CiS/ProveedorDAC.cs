using BE.CiS;
using Logger.CiS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAC.CiS
{
    public class ProveedorDAC
    {
        Conexion conn = new Conexion();
        ProjectLogger logs = new ProjectLogger();

        public bool InsertarProveedor(Proveedor proveedor)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "InsertProveedor";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("_descripcion", proveedor.Descripcion);
                    cmd.Parameters.AddWithValue("_direccion", proveedor.Direccion);
                    cmd.Parameters.AddWithValue("_telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("_mail", proveedor.Mail);
                    cmd.Parameters.AddWithValue("_idCateProv", proveedor.IdCateProve);
                    cmd.Parameters.AddWithValue("_fechaCreacion", proveedor.FechaCreacion);
                    cmd.Parameters.AddWithValue("_creadoPor", proveedor.CreadoPor);
                    cmd.Parameters.AddWithValue("_fechaActualizacion", proveedor.FechaActualizacion);
                    cmd.Parameters.AddWithValue("_actualizadoPor", proveedor.ActualizadoPor);
                    cmd.Parameters.AddWithValue("_isActive", proveedor.IsActive);
                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "InsertarProveedor", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "InsertarProveedor", UserSettings.User);
            }
            return flag;
        }

        public bool ActualizarProveedor(Proveedor proveedor)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "UpdateProveedor";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", proveedor.Id);
                    cmd.Parameters.AddWithValue("_nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("_descripcion", proveedor.Descripcion);
                    cmd.Parameters.AddWithValue("_direccion", proveedor.Direccion);
                    cmd.Parameters.AddWithValue("_telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("_mail", proveedor.Mail);
                    cmd.Parameters.AddWithValue("_idCateProv", proveedor.IdCateProve);
                    cmd.Parameters.AddWithValue("_fechaActualizacion", proveedor.FechaActualizacion);
                    cmd.Parameters.AddWithValue("_actualizadoPor", proveedor.ActualizadoPor);
                    cmd.Parameters.AddWithValue("_isActive", proveedor.IsActive);
                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "ActualizarProveedor", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "ActualizarProveedor", UserSettings.User);
            }
            return flag;
        }

        public Proveedor GetProveedor(int id)
        {
            Proveedor proveedor = new Proveedor();
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "GetProveedor";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            proveedor.Id = Convert.ToInt16(reader["id"]);
                            proveedor.Nombre = reader["nombre"].ToString();
                            proveedor.Descripcion = reader["descripcion"].ToString();
                            proveedor.Direccion = reader["direccion"].ToString();
                            proveedor.Telefono = reader["telefono"].ToString();
                            proveedor.Mail = reader["mail"].ToString();
                            proveedor.IdCateProve = Convert.ToInt16(reader["idCateProve"]);
                            proveedor.IsActive = Convert.ToInt16(reader["isActive"]);
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "GetProveedor", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "GetProveedor", UserSettings.User);
            }
            return proveedor;
        }

        public List<Proveedor> GetProveedores()
        {
            List<Proveedor> list = new List<Proveedor>();
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "GetUsuarios";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        
                        while (reader.Read())
                        {
                            list.Add(new Proveedor
                            {
                                Id = Convert.ToInt16(reader["id"]),
                                Nombre = reader["nombre"].ToString(),
                                Descripcion = reader["descripcion"].ToString(),
                                Direccion = reader["direccion"].ToString(),
                                Telefono = reader["telefono"].ToString(),
                                Mail = reader["mail"].ToString(),
                                IdCateProve = Convert.ToInt16(reader["idCateProve"]),
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
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "GetProveedores", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "GetProveedores", UserSettings.User);
            }
            return list;
        }

    }
}
