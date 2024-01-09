using Infrastructure.Database;
using Infrastructure.DTO;
using Infrastructure.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GenreRepository : IGenreRepository
    {
        private DbConnect dbConnect = new DbConnect();

        public IReadOnlyList<ArtistDTO> GetAllArtistBaseOnGenre(GenreDTO genreDto)
        {
            List<ArtistDTO> artistDtos = new List<ArtistDTO>();

            try
            {
                string querry = "SELECT * FROM artist AS a JOIN artistgenre AS ag ON a.artistid = ag.artistid JOIN genre AS g ON g.genreid = ag.genreid WHERE g.genreid = (SELECT genreid FROM genre WHERE genre.genrename = @genreName)";

                using (MySqlCommand cmd = dbConnect.ExecuteCommand(querry))
                {
                    cmd.Parameters.AddWithValue("@genreName", genreDto.name);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            artistDtos.Add(
                                new ArtistDTO(reader.GetString(reader.GetOrdinal("artistName")))
                            );
                        }

                        return artistDtos.AsReadOnly();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return artistDtos.AsReadOnly();
            }
        }

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
    }
}
