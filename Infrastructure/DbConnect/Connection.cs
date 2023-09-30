using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Infrastructure.DbConnect
{
    public class Connection
    {
        private static MySqlConnection connectMySql;

        static string server = "localhost";
        static string port = "3306";
        static string database = "wokeup";
        static string Uid = "root";
        static string password = "password";

        public static MySqlConnection DbConnect()
        {
            if (connectMySql == null)
            {
                connectMySql = new MySqlConnection($"Server={server};Port={port};Database={database};Uid={Uid};Pwd={password};");
            }

            return connectMySql;
        }

        public static void connOpen()
        {
            if (connectMySql == null)
            {
                DbConnect();
            }

            if(connectMySql.State != ConnectionState.Open)
            {
                connectMySql.Open();
            }
        }


        public static void connClose()
        {
            if (connectMySql != null && connectMySql.State == ConnectionState.Open)
            {
                connectMySql.Close();
            }
        }
    }
}
