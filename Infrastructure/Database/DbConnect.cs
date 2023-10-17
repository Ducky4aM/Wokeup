using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;
using MySql.Data.MySqlClient;

namespace Infrastructure.Database
{
    public class DbConnect
    {
        public MySqlConnection connectMySql { get; private set; }

        private string server = "localhost";
        private string port = "3306";
        private string database = "wokeup";
        private string Uid = "root";
        private string password = "password";

        public DbConnect()
        {
            string connectionString = $"Server={server};Port={port};Database={database};Uid={Uid};Pwd={password};";
            connectMySql = new MySqlConnection(connectionString);
        }

        public void ConnOpen()
        {
            if (connectMySql.State == ConnectionState.Closed)
            {
                connectMySql.Open();
            }
        }

        public void ConnClose()
        {
            if (connectMySql.State == ConnectionState.Open)
            {
                connectMySql.Close();
            }
        }

        public MySqlCommand executeQuery(string query)
        {
            try
            {
                ConnOpen();
                MySqlCommand cmd = new MySqlCommand(query ,connectMySql);

                return cmd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}