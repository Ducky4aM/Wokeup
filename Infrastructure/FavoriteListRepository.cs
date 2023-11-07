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
            MySqlCommand cmd = dbConnect.executeQuery("SELECT * FROM favoritelist AS fl INNER JOIN user AS u WHERE u.userid = @userid AND fl.owner = u.userid ");
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

        public bool AddNewFavoriteList(FavoriteListDTO favoriteListDto, UserDTO userDto)
        {
            try
            {
                MySqlCommand cmd = dbConnect.executeQuery("INSERT INTO favoritelist (favoritelistname, owner) VALUES (@listName, @userId)");
                cmd.Parameters.AddWithValue("@listName", favoriteListDto.name);
                cmd.Parameters.AddWithValue("@userId", userDto.userId);

                cmd.ExecuteNonQuery();
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
                MySqlCommand cmd = dbConnect.executeQuery("DELETE FROM favoritelist WHERE favoritelistid = @id");
                cmd.Parameters.AddWithValue("@id", favoriteListDto.id);

                cmd.ExecuteNonQuery();

                return true;
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
                MySqlCommand cmd = dbConnect.executeQuery("INSERT INTO favoritelistsong (songid, favoritelistid) VALUES (@songid, @favoritelistid)");
                cmd.Parameters.AddWithValue("@songid", songDto.songId);
                cmd.Parameters.AddWithValue("@favoritelistid", favoriteListDto.id);

                cmd.ExecuteNonQuery();
                return true;
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
                MySqlCommand cmd = dbConnect.executeQuery("Delete FROM favoritelistsong WHERE songid = @songid AND favoritelistid = @favoritelistid");
                cmd.Parameters.AddWithValue("@songid", songDto.songId);
                cmd.Parameters.AddWithValue("@favoritelistid", favoriteListDto.id);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
