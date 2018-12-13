using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System.IO;

namespace Logger.Prestamos
{
    public class logger
    {
        public void LogExceptionDB(MySqlConnection conn, Exception mysqlEx, string method, string username)
        {
            try
            {
                using (conn)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "InsertLog";
                    cmd.Parameters.AddWithValue("exception", mysqlEx);
                    cmd.Parameters.AddWithValue("method", method);
                    cmd.Parameters.AddWithValue("usename", username);
                    cmd.Parameters.AddWithValue("fecha", DateTime.UtcNow);
                }
            }
            catch (Exception)
            {

            }

        }

        public void LogException(Exception ex, string method, string username)
        {
            string path = @"c:\temp\CisLog.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Exception");
                    sw.WriteLine(ex);
                    sw.WriteLine(method);
                    sw.WriteLine(username);
                    sw.WriteLine(DateTime.UtcNow);
                }
            }
        }
    }
}
