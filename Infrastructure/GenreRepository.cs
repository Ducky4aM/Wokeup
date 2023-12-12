﻿using Infrastructure.Database;
using Infrastructure.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GenreRepository
    {
        private DbConnect dbConnect = new DbConnect();

        public IReadOnlyList<GenreDTO> GetAllGenre()
        {
            List<GenreDTO> genreList = new List<GenreDTO>();
            try
            {
                string querry = "SELECT * FROM genre ORDER BY genrename ASC";

                using (MySqlCommand cmd = dbConnect.ExecuteCommand(querry))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        genreList.Add(
                            new GenreDTO(reader.GetString(reader.GetOrdinal("genrename")))
                        );
                    }
                }
                return genreList.AsReadOnly();
 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return genreList.AsReadOnly();
            }
        }

        public IReadOnlyList<GenreDTO> GetUserPreferGenres(UserDTO userDto)
        {
            List<GenreDTO> genreList = new List<GenreDTO>();
            try
            {
                string querry = "SELECT * FROM genre AS g INNER JOIN userprefergenre AS pug ON pug.genreid = g.genreid WHERE pug.userid = (SELECT userid FROM user WHERE username = @username)";

                using (MySqlCommand cmd = dbConnect.ExecuteCommand(querry))
                {
                    cmd.Parameters.AddWithValue("@username", userDto.userName);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            genreList.Add(
                                new GenreDTO(reader.GetString(reader.GetOrdinal("genrename")))
                            );
                        }
                    }
                    return genreList.AsReadOnly();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return genreList.AsReadOnly();
            }
        }
    }
}
