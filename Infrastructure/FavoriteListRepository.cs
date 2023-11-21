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
    public class FavoriteListRepository
    {
        private DbConnect dbConnect = new DbConnect();

        public IReadOnlyList<FavoriteListDTO> GetAllFavoriteListBaseOnUser(UserDTO userDto)
        {
            try
            {
                string querry = "SELECT * FROM favoritelist AS fl INNER JOIN user AS u WHERE u.userid = @userid AND fl.owner = u.userid";

                using (MySqlCommand cmd = dbConnect.ExecuteCommand(querry))
                {
                    cmd.Parameters.AddWithValue("@userid", userDto.userId);

                    List<FavoriteListDTO> listOfFavolistList = new List<FavoriteListDTO>();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listOfFavolistList.Add(
                             new FavoriteListDTO(
                                    reader.GetInt32(reader.GetOrdinal("favoritelistid")),
                                    reader.GetString(reader.GetOrdinal("favoritelistname"))
                                 )
                            );
                        }
                    }

                    return listOfFavolistList.AsReadOnly();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public FavoriteListDTO AddNewFavoriteList(FavoriteListDTO favoriteListDto, UserDTO userDto)
        {
            try
            {
                string querry = "INSERT INTO favoritelist (favoritelistname, owner) VALUES (@listName, @userId); SELECT LAST_INSERT_ID();";

                using (MySqlCommand cmd = dbConnect.ExecuteCommand(querry))
                {
                    cmd.Parameters.AddWithValue("@listName", favoriteListDto.name);
                    cmd.Parameters.AddWithValue("@userId", userDto.userId);

                    int insertedId = Convert.ToInt32(cmd.ExecuteScalar());

                    return new FavoriteListDTO(insertedId, favoriteListDto.name);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RemoveFavoriteList(FavoriteListDTO favoriteListDto)
        {
            try
            {
                string querry = "DELETE FROM favoritelist WHERE favoritelistid = @id";

                using (MySqlCommand cmd = dbConnect.ExecuteCommand(querry))
                {
                    cmd.Parameters.AddWithValue("@id", favoriteListDto.id);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AddSongTofavorietList(SongDTO songDto, FavoriteListDTO favoriteListDto)
        {
            try
            {
                string querry = "INSERT INTO favoritelistsong (songid, favoritelistid) VALUES (@songid, @favoritelistid)";

                using (MySqlCommand cmd = dbConnect.ExecuteCommand(querry))
                {
                    cmd.Parameters.AddWithValue("@songid", songDto.songId);
                    cmd.Parameters.AddWithValue("@favoritelistid", favoriteListDto.id);
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool RemoveSongFomFavoriteList(SongDTO songDto, FavoriteListDTO favoriteListDto)
        {
            try
            {
                string querry = "Delete FROM favoritelistsong WHERE songid = @songid AND favoritelistid = @favoritelistid";

                using (MySqlCommand cmd = dbConnect.ExecuteCommand(querry))
                {
                    cmd.Parameters.AddWithValue("@songid", songDto.songId);
                    cmd.Parameters.AddWithValue("@favoritelistid", favoriteListDto.id);
                    cmd.ExecuteNonQuery();
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
