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
    public class Conexion
    {
        MySqlConnection conn;
        logger logs = new logger();

        string connectionString = "Data Source=localhost:3306;Database=prestamos;Uid=root;Pwd=1234";

        public Conexion()
        {
            this.conn = new MySqlConnection(connectionString);

        }

        public MySqlConnection Connect()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    OpenConnection();
                else
                    CloseConnection();
            }
            catch (Exception ex)
            {
                logs.LogException(ex, "Connect", UserSettings.User);
            }
            return conn;
        }

        public void OpenConnection()
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                logs.LogException(ex, "OpenConnection", UserSettings.User);
            }
        }

        public void CloseConnection()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                logs.LogException(ex, "CloseConnect", UserSettings.User);
            }
        }
    }
}
