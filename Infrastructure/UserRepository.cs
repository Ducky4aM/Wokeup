using Infrastructure.Database;
using Infrastructure.DTO;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository
    {
        private DbConnect dbConnect;

        public UserRepository(){
            this.dbConnect = new DbConnect();
        }

        public UserDTO? FindUser(UserDTO userDto)
        {
            string query = "SELECT * FROM user WHERE username=@name";

            using (MySqlCommand cmd = dbConnect.ExecuteCommand(query))
            {
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

        public void SetUserPreferGenre(UserDTO userDto, GenreDTO genreDto)
        {
            try
            {
                string query = "INSERT INTO userprefergenre(userid, genreid) VALUES((SELECT userid FROM user WHERE username = @username), (SELECT genreid FROM genre WHERE genrename = @genrename))";

                using (MySqlCommand cmd = dbConnect.ExecuteCommand(query))
                {
                    cmd.Parameters.AddWithValue("@username", userDto.userName);
                    cmd.Parameters.AddWithValue("@genrename", genreDto.name);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
