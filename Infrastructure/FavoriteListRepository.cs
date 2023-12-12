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
    public class FavoriteListRepository : IFavoriteRepository
    {
        private DbConnect dbConnect = new DbConnect();

        public IReadOnlyList<FavoriteListDTO> GetAllFavoriteListBaseOnUser(UserDTO userDto)
        {
            try
            {
                string query = "SELECT * FROM favoritelist AS fl INNER JOIN user AS u WHERE u.userid = (SELECT userid from user WHERE username = @username) AND fl.owner = u.userid";

                using (MySqlCommand cmd = dbConnect.ExecuteCommand(query))
                {
                    cmd.Parameters.AddWithValue("@username", userDto.userName);

                    List<FavoriteListDTO> listOfFavolistList = new List<FavoriteListDTO>();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listOfFavolistList.Add(
                             new FavoriteListDTO(
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

        public bool AddNewFavoriteList(FavoriteListDTO favoriteListDto, UserDTO userDto)
        {
            try
            {
                string query = "INSERT INTO favoritelist (favoritelistname, owner) VALUES (@listName, (SELECT userid FROM user WHERE username = @username));";

                using (MySqlCommand cmd = dbConnect.ExecuteCommand(query))
                {
                    cmd.Parameters.AddWithValue("@listName", favoriteListDto.name);
                    cmd.Parameters.AddWithValue("@username", userDto.userName);
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

        public bool RemoveFavoriteList(FavoriteListDTO favoriteListDto)
        {
            try
            {
                string query = "DELETE FROM favoritelist WHERE favoritelistid = (SELECT favoritelistid WHERE favoritelistname = @favoritelistname)";

                using (MySqlCommand cmd = dbConnect.ExecuteCommand(query))
                {
                    cmd.Parameters.AddWithValue("@favoritelistname", favoriteListDto.name);

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

        public bool AddSongTofavorietList(SongDTO songDto, FavoriteListDTO favoriteListDto)
        {
            try
            {
                string query = "INSERT INTO favoritelistsong(songid, favoritelistid) VALUES((SELECT songid FROM song WHERE songname = @songname), (SELECT favoritelistid FROM favoritelist WHERE favoritelistname = @favoritelistname))";

                using (MySqlCommand cmd = dbConnect.ExecuteCommand(query))
                {
                    cmd.Parameters.AddWithValue("@songname", songDto.songName);
                    cmd.Parameters.AddWithValue("@favoritelistname", favoriteListDto.name);
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

        public bool RemoveSongInFavoriteList(SongDTO songDto, FavoriteListDTO favoriteListDto)
        {
            try
            {
                string querry = "Delete FROM favoritelistsong WHERE songid = (SELECT songid FROM song WHERE songname = @songname) AND favoritelistid = (SELECT favoritelistid FROM favoritelist WHERE favoritelistname = @favoritelistname)";

                using (MySqlCommand cmd = dbConnect.ExecuteCommand(querry))
                {
                    cmd.Parameters.AddWithValue("@songname", songDto.songName);
                    cmd.Parameters.AddWithValue("@favoritelistname", favoriteListDto.name);
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
    }
}
