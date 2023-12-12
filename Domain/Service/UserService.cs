using Infrastructure;
using Infrastructure.DTO;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class UserService
    {
        User user;

        public UserService(User user)
        {
            this.user = user;
        }

        public ServiceStatusResult setUserPreferGenre(Genre genre)
        {
            try
            {
                bool isAdded = this.user.AddPreferGenre(genre);

                if (isAdded == false)
                {
                    return ServiceStatusResult.Failure();
                }

                UserRepository userRepository = new UserRepository();

                userRepository.SetUserPreferGenre(new UserDTO(this.user.name), new GenreDTO(genre.name));

                return ServiceStatusResult.Success();
            }
            catch (Exception ex)
            {
                return ServiceStatusResult.Failure("Error",ex.Message);
            }
        }

        public bool IsUserHaveSongInFavoriteList()
        {
            List<IFavoriteList> favoriteLists = this.user.GetFavoriteLists().ToList();

            if (favoriteLists.Count == 0)
            {
                return false;
            }

            foreach(IFavoriteList favoriteList in favoriteLists)
            {
                if (favoriteList.GetSongs().Count > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public List<Genre> getSuggestGenreForUser()
        {
            List<Genre> genres = user.GetPreferGenres().ToList();
            List<IFavoriteList> favoriteLists = user.GetFavoriteLists().ToList();
            List<Song> allSong = new List<Song>();

            foreach (IFavoriteList favoriteList in favoriteLists)
            {
                 List<Song> songs = favoriteList.GetSongs().ToList();

                foreach (Song song in songs)
                {
                    allSong.Add(song);
                }
            }

            //sort song base on genre and set genre as the key. and count song in that group.
            var genreCounts = allSong.GroupBy(song => song.genre.name)
                                          .Select(group => new { genre = group.Key, count = group.Count() })
                                          .OrderBy(g => g.count)
                                          .ToArray();


            foreach (var genreCount in genreCounts)
            {
                if (genres.Any(genre => genre.name == genreCount.genre) == true)
                {
                    genres.Clear();    
                }

                //Add at the top of list genres
                genres.Insert(0, new Genre(genreCount.genre));
            }

            return genres;
        }
    }
}
