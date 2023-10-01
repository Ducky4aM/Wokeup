using Infrastructure.DbConnect;
using Infrastructure.DTO;
using MySql.Data.MySqlClient;

namespace Infrastructure
{
    public class SongRepository
    {
        private static List<SongDTO> listSong = new List<SongDTO>();

        public static List<SongDTO> GetAllSong()
        {
            try
            {
                Connection.connOpen();

                string sql = "SELECT * FROM song ORDER BY song.songlistened DESC";
                MySqlCommand cmd = new MySqlCommand(sql, Connection.DbConnect());

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listSong.Add(
                            new SongDTO(
                                reader.GetInt32(reader.GetOrdinal("songid")),
                                reader.GetString(reader.GetOrdinal("songname")),
                                reader.GetString(reader.GetOrdinal("songimage")),
                                reader.GetInt32(reader.GetOrdinal("songlistened"))
                            )
                        );
                    }
                }

                return listSong;
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