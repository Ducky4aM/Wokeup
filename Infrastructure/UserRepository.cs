using Infrastructure.Database;
using Infrastructure.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository
    {
        private DbConnect dbConnect = new DbConnect();
        public UserRepository(){}

        public UserDTO? AuthUser(string userName, string userPassword)
        {
            try
            {
                dbConnect.ConnOpen();

                string sql = "SELECT username FROM user WHERE username=@name AND userpassword=@password";
                MySqlCommand cmd = new MySqlCommand(sql, dbConnect.connectMySql);
                cmd.Parameters.AddWithValue("@name", userName);
                cmd.Parameters.AddWithValue("@password", userPassword);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new UserDTO((string)reader["username"]);
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbConnect.ConnClose();
            }
        }
    }
}
