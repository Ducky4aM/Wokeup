using Infrastructure;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Service
{
    public class FavoriteListService
    {
        private readonly FavoriteListRepository favoriteListRepository;
        private readonly SongRepository songRepository;
        private readonly User user;

        //hier kunnen IUser kunnen aangeven
        public FavoriteListService(User user)
        {
            this.user = user;
            this.favoriteListRepository = new FavoriteListRepository();
            this.songRepository = new SongRepository();
        }

        public ServiceStatusResult CreateFavoriteList(string name)
        {
            try
            {
                //TODO: hier controleren of het wel al bestaat in de list (hier vragen )
                //adding to database
                //combinatie tussen user and favoritelist uniek.
                //valideren nadat toegevoeg in databse
                FavoriteListDTO newFavoriteListDto = this.favoriteListRepository.AddNewFavoriteList(new FavoriteListDTO(name), new UserDTO(this.user.id));

                bool isAddedSucces = this.user.AddFavoriteList(new FavoriteList( newFavoriteListDto.name));

                if (isAddedSucces == false)
                {
                    return ServiceStatusResult.Failure("Error", $"Favorite list with name: {name} already exsit, please try other name!");
                }

                //hier kunnen misshien ook static klass maken met static method
                return ServiceStatusResult.Success("Succes", $"Created `{name}` list succesful!");
            }
            catch (Exception ex)
            {
                return ServiceStatusResult.Failure("Error", ex.Message);
            }
        }

        public ServiceStatusResult RemoveFavoriteList(FavoriteList favoriteList)
        {
            try
            {
                FavoriteListDTO favoriteListDTO = new FavoriteListDTO(favoriteList.id, favoriteList.name);
                //remove in databse
                bool isRemoved = this.favoriteListRepository.RemoveFavoriteList(favoriteListDTO);

                if (isRemoved)
                {
                    user.RemoveFavoriteList(favoriteList);
                }

                return ServiceStatusResult.Success();
            }
            catch (Exception ex)
            {
                return ServiceStatusResult.Failure("Error", ex.Message);
            }
        }

        public IReadOnlyList<FavoriteList> GetUserFavoriteLists()
        {
            IReadOnlyList<FavoriteListDTO> favoriteListsDto = this.favoriteListRepository.GetAllFavoriteListBaseOnUser(new UserDTO(user.id));

            foreach (FavoriteListDTO favoriteListDto in favoriteListsDto)
            {
                this.user.AddFavoriteList(new FavoriteList(favoriteListDto.id, favoriteListDto.name));
            }

            return user.GetFavoriteLists();
        }

        public ServiceStatusResult GetSongsFromFavoriteList(FavoriteList favoriteList)
        {
            FavoriteListDTO favoriteListDto = new FavoriteListDTO(favoriteList.id, favoriteList.name);
            IReadOnlyList<SongDTO> songsDto = this.songRepository.GetSongFromFavoriteList(favoriteListDto);
            List<Song> songs = new List<Song>();

            foreach (SongDTO songDto in songsDto)
            {
                bool isAddedSong = favoriteList.AddSongToFavoriteList(
                     new Song(
                         songDto.songId,
                         songDto.songName,
                         songDto.songImage,
                         songDto.songListened,
                         new Genre(songDto.genreDto.name),
                         new Artist(songDto.artistDto.name)
                         )
                     );

                if (isAddedSong == false)
                {
                    continue;
                }
            }

            return ServiceStatusResult.Success();
        }

        public ServiceStatusResult AddSongToFavoriteList(Song song, FavoriteList favoriteList)
        {
            SongDTO songDto = new SongDTO(song.id);
            FavoriteListDTO favoriteListDto = new FavoriteListDTO(favoriteList.id, favoriteList.name);

            this.favoriteListRepository.AddSongTofavorietList(songDto, favoriteListDto);

            bool isSongAdded = favoriteList.AddSongToFavoriteList(song);

            if (isSongAdded == false)
            {
                return ServiceStatusResult.Failure("Info", $"Song has already been added to {favoriteList.name} list, select another list!");
            }

            return ServiceStatusResult.Success();
        }

        public ServiceStatusResult RemoveSongInFavoriteList(Song song, FavoriteList favoriteList)
        {
            try
            {
                bool isRemoved = favoriteList.RemoveSongInFavoriteList(song);

                if (isRemoved == false)
                {
                    return ServiceStatusResult.Failure("error", " removed as it does not exist in the favorite list.");
                }

                favoriteListRepository.RemoveSongFomFavoriteList(new SongDTO(song.id), new FavoriteListDTO(favoriteList.id, favoriteList.name));

                return ServiceStatusResult.Success();
            }
            catch (Exception ex)
            {
                return ServiceStatusResult.Failure("error", ex.Message);
            }
        }
    }
}
