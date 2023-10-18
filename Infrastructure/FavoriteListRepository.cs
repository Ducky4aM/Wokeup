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

        public IReadOnlyList<FavoriteListDTO> GetAllFavoriteListBaseOnUserId(int id)
        {

            MySqlCommand cmd = dbConnect.executeQuery("SELECT * FROM favoritelist AS fl WHERE fl.owner=@id");
            cmd.Parameters.AddWithValue("@id", id);

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

        public bool AddNewFavoriteList(FavoriteListDTO favoriteListDto, int userId)
        {
            try
            {
                MySqlCommand cmd = dbConnect.executeQuery("INSERT INTO favoritelist (favoritelistname, owner) VALUES (@listname, @userid)");
                cmd.Parameters.AddWithValue("@listname", favoriteListDto.name);
                cmd.Parameters.AddWithValue("@userid", userId);

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
    }
}
