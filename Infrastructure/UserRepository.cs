using Infrastructure.DbConnect;
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
        public static UserDTO AuthUser(string userName, string userPassword)
        {
            try
            {
                Connection.connOpen();

                string sql = "SELECT username FROM user WHERE username=@name AND userpassword=@password";
                MySqlCommand cmd = new MySqlCommand(sql, Connection.DbConnect());
                cmd.Parameters.AddWithValue("@name", userName);
                cmd.Parameters.AddWithValue("@password", userPassword);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create and return a UserDTO when a user is found
                        return new UserDTO((string)reader["username"]);
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, and if needed, log or rethrow it
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.connClose();
            }
        }
    }
}
