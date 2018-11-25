using BE.CiS;
using Logger.CiS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAC.CiS
{
    public class FacturaDAC
    {
        Conexion conn = new Conexion();
        ProjectLogger logs = new ProjectLogger();

        public bool InsertarFactura(Factura factura)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "InsertFactura";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_total", factura.Total);
                    cmd.Parameters.AddWithValue("_cliente", factura.Cliente);
                    cmd.Parameters.AddWithValue("_idDetaFact", factura.IdDetaFact);
                    cmd.Parameters.AddWithValue("_tipoPago", factura.TipoPago);
                    cmd.Parameters.AddWithValue("_fechaCreacion", factura.FechaCreacion);
                    cmd.Parameters.AddWithValue("_creadoPor", factura.CreadoPor);
                    cmd.Parameters.AddWithValue("_fechaActualizacion", factura.FechaActualizacion);
                    cmd.Parameters.AddWithValue("_actualizadoPor", factura.ActualizadoPor);
                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "InsertarFactura", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "InsertarFactura", UserSettings.User);
            }
            return flag;
        }

        public bool ActualizarFactura(Factura factura)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "UpdateFactura";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", factura.Id);
                    cmd.Parameters.AddWithValue("_total", factura.Total);
                    cmd.Parameters.AddWithValue("_cliente", factura.Cliente);
                    cmd.Parameters.AddWithValue("_idDetaFact", factura.IdDetaFact);
                    cmd.Parameters.AddWithValue("_tipoPago", factura.TipoPago);
                    cmd.Parameters.AddWithValue("_fechaActualizacion", factura.FechaActualizacion);
                    cmd.Parameters.AddWithValue("_actualizadoPor", factura.ActualizadoPor);
                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "ActualizarFactura", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "ActualizarFactura", UserSettings.User);
            }
            return flag;
        }

        public Factura GetFactura(int id)
        {
            Factura factura = new Factura();
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "GetFactura";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            factura.Id = Convert.ToInt16(reader["id"]);
                            factura.Total = Convert.ToDouble(reader["nombre"]);
                            factura.Cliente = reader["cliente"].ToString();
                            factura.TipoPago = reader["TipoPago"].ToString();
                            factura.IdDetaFact = Convert.ToInt16(reader["idDetaFact"]);
                            factura.FechaCreacion = Convert.ToDateTime(reader["fechaCreacion"]);
                            factura.CreadoPor = reader["creadoPor"].ToString();
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "GetFactura", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "GetFactura", UserSettings.User);
            }
            return factura;
        }

        public List<Factura> GetFacturas()
        {
            List<Factura> list = new List<Factura>();
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "GetFacturas";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            list.Add(new Factura
                            {
                                Id = Convert.ToInt16(reader["id"]),
                                Total = Convert.ToDouble(reader["nombre"]),
                                Cliente = reader["cliente"].ToString(),
                                TipoPago = reader["TipoPago"].ToString(),
                                IdDetaFact = Convert.ToInt16(reader["idDetaFact"]),
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
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "GetFacturas", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "GetFacturas", UserSettings.User);
            }
            return list;
        }
    }
}
