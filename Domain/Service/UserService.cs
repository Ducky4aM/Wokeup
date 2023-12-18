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
            if (user == null)
            {
                throw new ArgumentNullException("User is null");
            }

            if (userRepository == null)
            {
                throw new ArgumentNullException("UserRepository is null");
            }

            this.user = user;
            this.userRepository = userRepository;
        }

        public ServiceStatusResult SetUserPreferGenre(Genre genre)
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

        public List<Genre> GetSuggestGenreForUser()
        {
            List<Genre> genres = new List<Genre>() {
                user.GetPreferGenre()
            };

            Dictionary<string, int> genreCounts = new Dictionary<string, int>();

            List<Song> allSong = new List<Song>();

            foreach (IFavoriteList favoriteList in user.GetFavoriteLists().ToList())
            {
                foreach (Song song in favoriteList.GetSongs().ToList())
                {
                    string genreName = song.genre.name;

                    if (genreCounts.ContainsKey(genreName))
                    {
                        genreCounts[genreName]++;
                    }
                    else
                    {
                        genreCounts.Add(genreName, 1);
                    }
                }
            }

            // Sort genres based on song count
            var sortedGenres = genreCounts.OrderBy(kv => kv.Value).Select(kv => kv.Key).ToList();

            foreach (string genreName in sortedGenres)
            {
                genres.Insert(0, new Genre(genreName));
            }

            genres = genres.DistinctBy(g => g.name).ToList();

            return genres ;
        }
    }
}
