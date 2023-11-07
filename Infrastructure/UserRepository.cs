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

        public UserDTO? FindUser(UserDTO userDto)
        {
            MySqlCommand cmd = dbConnect.executeQuery("SELECT * FROM user WHERE username=@name");
            cmd.Parameters.AddWithValue("@name", userDto.userName);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    return new UserDTO(
                        reader.GetInt32(reader.GetOrdinal("userid")),
                        reader.GetString(reader.GetOrdinal("username")),
                        reader.GetString(reader.GetOrdinal("userpassword"))
                        );
                }

                return null;
            }
        }
    }
}
