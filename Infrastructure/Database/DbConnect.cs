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
        private string server;
        private string port;
        private string database;
        private string Uid;
        private string password;

        public DbConnect(string server, string port, string database, string Uid, string password)
        {
            this.server = server;
            this.port = port;
            this.database = database;
            this.Uid = Uid;
            this.password = password;
        }

        public DbConnect(): this("localhost", "3306", "wokeup", "root", "password")
        {
        }

        public MySqlConnection GetConnection()
        {
            string connectionString = $"Server={server};Port={port};Database={database};Uid={Uid};Pwd={password};";
            return new MySqlConnection(connectionString);
        }

        public MySqlCommand ExecuteCommand(string query)
        {
            MySqlConnection connection = GetConnection();

            try
            {
                connection.Open();
                return new MySqlCommand(query, connection);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating command: " + ex.Message);
            }
        }
    }
}