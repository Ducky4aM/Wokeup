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

        public UserDTO? AuthUser(UserDTO userDto)
        {
            MySqlCommand cmd = dbConnect.executeQuery("SELECT * FROM user WHERE username=@name AND userpassword=@password");
            cmd.Parameters.AddWithValue("@name", userDto.username);
            cmd.Parameters.AddWithValue("@password", userDto.password);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    return new UserDTO(
                        reader.GetString(reader.GetOrdinal("username")),
                        reader.GetInt32(reader.GetOrdinal("userid"))
                        );
                }
                return null;
            }
        }
    }
}
