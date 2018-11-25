using BE.CiS;
using Logger.CiS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAC.CiS
{
    public class Conexion
    {
        MySqlConnection conn;
        ProjectLogger logs = new ProjectLogger();

        string connectionString = "Data Source=localhost:3306;Database=cis;Uid=root;Pwd=$1Q2W3e4r$";

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
            catch(Exception ex)
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
