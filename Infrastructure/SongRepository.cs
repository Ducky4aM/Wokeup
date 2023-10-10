using Infrastructure.Database;
using Infrastructure.DTO;
using MySql.Data.MySqlClient;

namespace Infrastructure
{
    public class SongRepository
    {
        private DbConnect dbConnect = new DbConnect();
        public List<SongDTO> GetAllSong()
        {
            try
            {
                dbConnect.ConnOpen();
                string sql = "SELECT * FROM song ORDER BY song.songlistened DESC";
                MySqlCommand cmd = new MySqlCommand(sql, dbConnect.connectMySql);
                List<SongDTO> listSongs = new List<SongDTO>();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listSongs.Add(
                            new SongDTO(
                                reader.GetInt32(reader.GetOrdinal("songid")),
                                reader.GetString(reader.GetOrdinal("songname")),
                                reader.GetString(reader.GetOrdinal("songimage")),
                                reader.GetInt32(reader.GetOrdinal("songlistened"))
                            )
                        );
                    }
                }

                return listSongs;
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