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
    public class GenreRepository
    {
        private DbConnect dbConnect = new DbConnect();

        public IReadOnlyList<GenreDTO> GetAllGenre()
        {
            List<GenreDTO> genreList = new List<GenreDTO>();
            try
            {
                MySqlCommand cmd = dbConnect.executeQuery("SELECT * FROM genre ORDER BY genrename ASC");
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
