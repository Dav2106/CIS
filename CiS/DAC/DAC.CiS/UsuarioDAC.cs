using BE.CiS;
using Logger.CiS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAC.CiS
{
    public class UsuarioDAC
    {
        Conexion conn = new Conexion();
        ProjectLogger logs = new ProjectLogger();

        public bool InsertarUsuario(Usuario usuario)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "InsertUsuario";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("_username", usuario.Username);
                    cmd.Parameters.AddWithValue("_password", usuario.Password);
                    cmd.Parameters.AddWithValue("_isAdmin", usuario.IsAdmin);
                    cmd.Parameters.AddWithValue("_isActive", usuario.IsActive);
                    cmd.Parameters.AddWithValue("_fechaCreacion", usuario.FechaCreacion);
                    cmd.Parameters.AddWithValue("_creadoPor", usuario.CreadoPor);
                    cmd.Parameters.AddWithValue("_fechaActualizacion", usuario.FechaActualizacion);
                    cmd.Parameters.AddWithValue("_actualizadoPor", usuario.ActualizadoPor);
                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch(MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "InsertarUsuario", UserSettings.User);
            }catch(Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "InsertUsuario", UserSettings.User);
            }
            return flag;
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "UpdateUsuario";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", usuario.Id);
                    cmd.Parameters.AddWithValue("_nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("_username", usuario.Username);
                    cmd.Parameters.AddWithValue("_password", usuario.Password);
                    cmd.Parameters.AddWithValue("_isAdmin", usuario.IsAdmin);
                    cmd.Parameters.AddWithValue("_isActive", usuario.IsActive);
                    cmd.Parameters.AddWithValue("_fechaActualizacion", usuario.FechaActualizacion);
                    cmd.Parameters.AddWithValue("_actualizadoPor", usuario.ActualizadoPor);
                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "ActualizarUsuario", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "ActualizarUsuario", UserSettings.User);
            }
            return flag;
        }

        public Usuario GetUsuario(int id)
        {
            Usuario usuario = new Usuario();
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "GetUsuario";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            usuario.Id = Convert.ToInt16(reader["id"]);
                            usuario.Nombre = reader["nombre"].ToString();
                            usuario.Username = reader["Username"].ToString();
                            usuario.IsAdmin = Convert.ToInt16(reader["isAdmin"]);
                            usuario.IsActive = Convert.ToInt16(reader["isActive"]);
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "GetUsuario", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "GetUsuario", UserSettings.User);
            }
            return usuario;
        }

        public List<Usuario> GetUsuarios()
        {
            List<Usuario> list = new List<Usuario>();
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
                            list.Add(new Usuario
                            {
                                Id = Convert.ToInt16(reader["id"]),
                                Nombre = reader["nombre"].ToString(),
                                Username = reader["Username"].ToString(),
                                IsAdmin = Convert.ToInt16(reader["isAdmin"]),
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
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "GetUsuarios", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "GetUsuarios", UserSettings.User);
            }
            return list;
        }
    }
}
