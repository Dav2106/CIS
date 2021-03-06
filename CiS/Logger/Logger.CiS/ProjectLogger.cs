﻿using MySql.Data.MySqlClient;
using System;
using System.IO;

namespace Logger.CiS
{
    public class ProjectLogger
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
            catch (Exception )
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
