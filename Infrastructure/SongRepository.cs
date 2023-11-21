using Infrastructure.Database;
using Infrastructure.DTO;
using MySql.Data.MySqlClient;

namespace Infrastructure
{
    public class SongRepository
    {
        private DbConnect dbConnect = new DbConnect();

        public IReadOnlyList<SongDTO> GetTopListenedSongs()
        {
            try
            {
                string querry = @"SELECT * FROM song AS so 
                INNER JOIN genre 
                INNER JOIN artist as art 
                ON so.genre = genre.genreid 
                AND so.artistid = art.artistid 
                ORDER BY so.songlistened DESC";

                List<SongDTO> listSongs = new List<SongDTO>();

                using(MySqlCommand cmd = dbConnect.ExecuteCommand(querry))
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
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }


        public IReadOnlyList<SongDTO> GetSongFromFavoriteList(FavoriteListDTO favoriteListDto)
        {
            try
            {
                string query = @"SELECT * FROM favoritelist AS fvl 
                    INNER JOIN favoritelistsong AS fvls ON fvl.favoritelistid = fvls.favoritelistid 
                    INNER JOIN song AS s ON fvls.songid = s.songid 
                    INNER JOIN genre AS ge ON s.genre = ge.genreid 
                    INNER JOIN artist AS art ON s.artistid = art.artistid 
                    WHERE fvl.favoritelistid = @id;";

                List<SongDTO> listSongs = new List<SongDTO>();

                using (MySqlCommand cmd = this.dbConnect.ExecuteCommand(query))
                {
                    cmd.Parameters.AddWithValue("@id", favoriteListDto.id);

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
                }

                return listSongs.AsReadOnly();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IReadOnlyList<SongDTO> GetSongsBaseOnGenre(GenreDTO genreDto)
        {
            try
            {
                string querry = @"SELECT * FROM song as s 
                INNER JOIN genre as g ON s.genre = g.genreid 
                INNER JOIN artist as a ON s.artistid = a.artistid
                WHERE g.genrename = @name;";

                List<SongDTO> listSongs = new List<SongDTO>();

                using (MySqlCommand cmd = this.dbConnect.ExecuteCommand(querry))
                {
                    cmd.Parameters.AddWithValue("@name", genreDto.name);

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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}