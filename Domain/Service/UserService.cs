using Domain.Interface;
using Domain.Service.Interface;
using Infrastructure;
using Infrastructure.DTO;
using Infrastructure.Interface;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class UserService : IUserService
    {
        private IUser user;

        private IUserRepository userRepository;

        public UserService(IUser user, IUserRepository userRepository)
        {
            this.user = user;
            this.userRepository = userRepository;
        }

        public UserService(IUser user)
        {
            this.user = user;
        }

        public ServiceStatusResult setUserPreferGenre(Genre genre)
        {
            if (genre == null)
            {
                throw new ArgumentException("Genre is null");
            }

            bool isAdded = this.user.SetPreferGenre(genre);

            if (isAdded == false)
            {
                return ServiceStatusResult.Failure();
            }

            bool isAddedInDatabase = userRepository.SetUserPreferGenre(new UserDTO(this.user.name), new GenreDTO(genre.name));

            if (isAddedInDatabase == false)
            {
                return ServiceStatusResult.Failure("Error", "Can't added prefer genre in database");
            }

            return ServiceStatusResult.Success();
        }

        public bool IsUserHaveSongInFavoriteList()
        {
            List<IFavoriteList> favoriteLists = this.user.GetFavoriteLists().ToList();

            if (favoriteLists.Count == 0)
            {
                return false;
            }

            foreach (IFavoriteList favoriteList in favoriteLists)
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
            List<Genre> genres = new List<Genre>() {
                user.GetPreferGenre()
            };

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
