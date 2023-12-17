using Infrastructure.Database;
using Infrastructure.DTO;
using Infrastructure.Interface;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private DbConnect dbConnect;

        public UserRepository()
        {
            this.dbConnect = new DbConnect();
        }

        public UserDTO? FindUser(UserDTO userDto)
        {
            string query = "SELECT * FROM user as u LEFT JOIN genre as g ON u.prefergenreid = g.genreid WHERE username=@name AND userpassword=@password";

            using (MySqlCommand cmd = dbConnect.ExecuteCommand(query))
            {
                cmd.Parameters.AddWithValue("@name", userDto.userName);
                cmd.Parameters.AddWithValue("@password", userDto.password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(reader.GetOrdinal("genrename")) == true)
                        {
                            return new UserDTO(
                              reader.GetString(reader.GetOrdinal("username")),
                              reader.GetString(reader.GetOrdinal("userpassword"))
                            );
                        }

                        return new UserDTO(
                                reader.GetString(reader.GetOrdinal("username")),
                                reader.GetString(reader.GetOrdinal("userpassword")),
                                new GenreDTO(reader.GetString(reader.GetOrdinal("genrename")))
                            );
                    }

                    return null;
                }
            }
        }

        public bool SetUserPreferGenre(UserDTO userDto, GenreDTO genreDto)
        {
            try
            {
                string query = "UPDATE user SET prefergenreid  = (SELECT genreid FROM genre WHERE genrename = @genrename) WHERE username = @username";

                using (MySqlCommand cmd = dbConnect.ExecuteCommand(query))
                {
                    cmd.Parameters.AddWithValue("@username", userDto.userName);
                    cmd.Parameters.AddWithValue("@genrename", genreDto.name);
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public void CreateNewUser(UserDTO userDto)
        {
            try
            {
                string query = "INSERT INTO user(username, userpassword) VALUES (@username, @userpassword)";

                using (MySqlCommand cmd = dbConnect.ExecuteCommand(query))
                {
                    cmd.Parameters.AddWithValue("@username", userDto.userName);
                    cmd.Parameters.AddWithValue("@userpassword", userDto.password);
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
