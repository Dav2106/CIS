using BE.CiS;
using Logger.CiS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAC.CiS
{
    public class CronogramaDAC
    {
        Conexion conn = new Conexion();
        ProjectLogger logs = new ProjectLogger();

        public bool InsertarCronograma(Cronograma cronograma)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "InsertCronograma";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_fechaRecibo", cronograma.FechaRecibo);
                    cmd.Parameters.AddWithValue("_idProd", cronograma.IdProd);
                    cmd.Parameters.AddWithValue("_idProve", cronograma.IdProve);
                    cmd.Parameters.AddWithValue("_cantidad", cronograma.Cantidad);
                    cmd.Parameters.AddWithValue("_pago", cronograma.Pago);
                    cmd.Parameters.AddWithValue("_isActive", cronograma.IsActive);
                    cmd.Parameters.AddWithValue("_fechaCreacion", cronograma.FechaCreacion);
                    cmd.Parameters.AddWithValue("_creadoPor", cronograma.CreadoPor);
                    cmd.Parameters.AddWithValue("_fechaActualizacion", cronograma.FechaActualizacion);
                    cmd.Parameters.AddWithValue("_actualizadoPor", cronograma.ActualizadoPor);
                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "InsertarCronograma", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "InsertarCronograma", UserSettings.User);
            }
            return flag;
        }

        public bool ActualizarCronograma(Cronograma cronograma)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "UpdateCronograma";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", cronograma.Id);
                    cmd.Parameters.AddWithValue("_fechaRecibo", cronograma.FechaRecibo);
                    cmd.Parameters.AddWithValue("_idProd", cronograma.IdProd);
                    cmd.Parameters.AddWithValue("_idProve", cronograma.IdProve);
                    cmd.Parameters.AddWithValue("_cantidad", cronograma.Cantidad);
                    cmd.Parameters.AddWithValue("_pago", cronograma.Pago);
                    cmd.Parameters.AddWithValue("_isActive", cronograma.IsActive);
                    cmd.Parameters.AddWithValue("_fechaActualizacion", cronograma.FechaActualizacion);
                    cmd.Parameters.AddWithValue("_actualizadoPor", cronograma.ActualizadoPor);
                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "ActualizarCronograma", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "ActualizarCronograma", UserSettings.User);
            }
            return flag;
        }

        public Cronograma GetCronograma(int id)
        {
            Cronograma cronograma = new Cronograma();
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "GetCronograma";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            cronograma.Id = Convert.ToInt16(reader["id"]);
                            cronograma.FechaRecibo = Convert.ToDateTime(reader["fechaRecibo"]);
                            cronograma.IdProd = Convert.ToInt16(reader["idProd"]);
                            cronograma.IdProve = Convert.ToInt16(reader["idProve"]);
                            cronograma.Cantidad = Convert.ToInt16(reader["cantidad"]);
                            cronograma.Pago = Convert.ToDouble(reader["pago"]);
                            cronograma.IsActive = Convert.ToInt16(reader["isActive"]);
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "GetCronograma", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "GetCronograma", UserSettings.User);
            }
            return cronograma;
        }

        public List<Cronograma> GetCronogramas()
        {
            List<Cronograma> list = new List<Cronograma>();
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "GetCronogramas";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            list.Add(new Cronograma
                            {
                                Id = Convert.ToInt16(reader["id"]),
                                FechaRecibo = Convert.ToDateTime(reader["fechaRecibo"]),
                                IdProd = Convert.ToInt16(reader["idProd"]),
                                IdProve = Convert.ToInt16(reader["idProve"]),
                                Cantidad = Convert.ToInt16(reader["cantidad"]),
                                Pago = Convert.ToDouble(reader["pago"]),
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
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "GetCronogramas", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "GetCronogramas", UserSettings.User);
            }
            return list;
        }
    }
}
