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
            MySqlCommand cmd = this.dbConnect.executeQuery("SELECT * FROM song AS so INNER JOIN genre INNER JOIN artist as art ON so.genre = genre.genreid AND so.artistid = art.artistid ORDER BY so.songlistened DESC");
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
                            reader.GetInt32(reader.GetOrdinal("songlistened")),
                            new GenreDTO(reader.GetString(reader.GetOrdinal("genrename"))),
                            new ArtistDTO(reader.GetString(reader.GetOrdinal("artistname")))
                        )
                    );
                }
            }

            return listSongs.AsReadOnly();
        }


        public IReadOnlyList<SongDTO> GetSongFromFavoriteList(FavoriteListDTO favoriteListDto)
        {
            MySqlCommand cmd = this.dbConnect.executeQuery(
                "SELECT * FROM favoritelist AS fvl " +
                "INNER JOIN favoritelistsong AS fvls ON fvl.favoritelistid = fvls.favoritelistid " +
                "INNER JOIN song AS s ON fvls.songid = s.songid " +
                "INNER JOIN genre AS ge ON s.genre = ge.genreid " +
                "INNER JOIN artist AS art ON s.artistid = art.artistid " +
                "WHERE fvl.favoritelistid = @id;"
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
                            reader.GetInt32(reader.GetOrdinal("songlistened")),
                            new GenreDTO(reader.GetString(reader.GetOrdinal("genrename"))),
                            new ArtistDTO(reader.GetString(reader.GetOrdinal("artistname")))
                        )
                    );
                }
            }

            return listSongs.AsReadOnly();
        }

        public IReadOnlyList<SongDTO> GetSongsBaseOnGenre(GenreDTO genreDto)
        {
            MySqlCommand cmd = this.dbConnect.executeQuery(
                "SELECT * FROM song as s " +
                "INNER JOIN genre as g ON s.genre = g.genreid " +
                "INNER JOIN artist as a ON s.artistid = a.artistid " +
                "WHERE g.genrename = @name;"
            );

            cmd.Parameters.AddWithValue("@name", genreDto.name);

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
                            reader.GetInt32(reader.GetOrdinal("songlistened")),
                            new GenreDTO(reader.GetString(reader.GetOrdinal("genrename"))),
                            new ArtistDTO(reader.GetString(reader.GetOrdinal("artistname")))
                        )
                    );
                }
            }

            return listSongs.AsReadOnly();
        }
    }
}