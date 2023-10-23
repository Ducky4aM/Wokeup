using Infrastructure.Database;
using Infrastructure.DTO;
using MySql.Data.MySqlClient;

namespace Infrastructure
{
    public class SongRepository
    {
        private DbConnect dbConnect = new DbConnect();

        public IReadOnlyList<SongDTO> GetTopSongs()
        {
            MySqlCommand cmd = this.dbConnect.executeQuery("SELECT * FROM song ORDER BY song.songlistened DESC");
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

            return listSongs.AsReadOnly();
        }


        public IReadOnlyList<SongDTO> GetSongFromFavoriteList(FavoriteListDTO favoriteListDto)
        {
            MySqlCommand cmd = this.dbConnect.executeQuery(
                "SELECT s.* FROM favoritelist AS fvl INNER JOIN favoritelistsong fvls ON fvl.favoritelistid = fvls.favoritelistid INNER JOIN song AS s ON fvls.songid = s.songid WHERE fvl.favoritelistid = @id; "
                );
            cmd.Parameters.AddWithValue("@id", favoriteListDto.id);

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

            return listSongs.AsReadOnly();
        }
    }
}