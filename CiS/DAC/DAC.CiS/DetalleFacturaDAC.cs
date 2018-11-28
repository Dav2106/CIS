using BE.CiS;
using Logger.CiS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAC.CiS
{
    public class DetalleFacturaDAC
    {
        Conexion conn = new Conexion();
        ProjectLogger logs = new ProjectLogger();

        public bool InsertarDetalleFactura(DetalleFactura detalleFactura)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "InsertDetalleFactura";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_transaccion", detalleFactura.Transaccion);
                    cmd.Parameters.AddWithValue("_idProducto", detalleFactura.IdProducto);
                    cmd.Parameters.AddWithValue("_cantidad", detalleFactura.Cantidad);
                    cmd.Parameters.AddWithValue("_fechaCreacion", detalleFactura.FechaCreacion);
                    cmd.Parameters.AddWithValue("_creadoPor", detalleFactura.CreadoPor);
                    cmd.Parameters.AddWithValue("_fechaActualizacion", detalleFactura.FechaActualizacion);
                    cmd.Parameters.AddWithValue("_actualizadoPor", detalleFactura.ActualizadoPor);
                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "InsertarDetalleFactura", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "InsertarDetalleFactura", UserSettings.User);
            }
            return flag;
        }

        public bool ActualizarDetalleFactura(DetalleFactura detalleFactura)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "UpdateDetalleFactura";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", detalleFactura.Id);
                    cmd.Parameters.AddWithValue("_transaccion", detalleFactura.Transaccion);
                    cmd.Parameters.AddWithValue("_idProducto", detalleFactura.IdProducto);
                    cmd.Parameters.AddWithValue("_cantidad", detalleFactura.Cantidad);
                    cmd.Parameters.AddWithValue("_fechaActualizacion", detalleFactura.FechaActualizacion);
                    cmd.Parameters.AddWithValue("_actualizadoPor", detalleFactura.ActualizadoPor);
                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "ActualizarDetalleFactura", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "ActualizarDetalleFactura", UserSettings.User);
            }
            return flag;
        }

        public DetalleFactura GetDetalleFactura(int id)
        {
            DetalleFactura detalleFactura = new DetalleFactura();
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "GetDetalleFactura";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            detalleFactura.Id = Convert.ToInt16(reader["id"]);
                            detalleFactura.Transaccion = Convert.ToInt16(reader["transaccion"]);
                            detalleFactura.IdProducto = Convert.ToInt16(reader["idProducto"]);
                            detalleFactura.Cantidad = Convert.ToInt16(reader["cantidad"]);
                            detalleFactura.FechaCreacion = Convert.ToDateTime(reader["fechaCreacion"]);
                            detalleFactura.CreadoPor = reader["creadoPor"].ToString();
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "GetDetalleFactura", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "GetDetalleFactura", UserSettings.User);
            }
            return detalleFactura;
        }

        public List<DetalleFactura> GetDetallesFactura()
        {
            List<DetalleFactura> list = new List<DetalleFactura>();
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "GetDetallesFactura";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            list.Add(new DetalleFactura
                            {
                                Id = Convert.ToInt16(reader["id"]),
                                Transaccion = Convert.ToInt16(reader["transaccion"]),
                                IdProducto = Convert.ToInt16(reader["idProducto"]),
                                Cantidad = Convert.ToInt16(reader["cantidad"]),
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
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "GetDetallesFactura", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "GetDetallesFactura", UserSettings.User);
            }
            return list;
        }
    }
}
