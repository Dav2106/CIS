using BE.Prestamos;
using Logger.Prestamos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC.Prestamos
{
   public class TecnicoDAC
    {
        Conexion conn = new Conexion();
        logger logs = new logger();
        public bool InsertarUsuario(Tecnico tecnico)
        {
            bool flag = false;
            try
            {
                using (conn.Connect())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "InsertTecnico";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("tcNombreCompleto", tecnico.nombre);
                    cmd.Parameters.AddWithValue("tcAreaAtencion", tecnico.AreaAtencion);

                    if (cmd.ExecuteNonQuery() > 0)
                        flag = true;
                    else
                        flag = false;
                }
            }
            catch (MySqlException mysqlEx)
            {
                logs.LogExceptionDB(conn.Connect(), mysqlEx, "InsertTecnico", UserSettings.User);
            }
            catch (Exception ex)
            {
                logs.LogExceptionDB(conn.Connect(), ex, "InsertTecnico", UserSettings.User);
            }
            return flag;
        }
    }
}
