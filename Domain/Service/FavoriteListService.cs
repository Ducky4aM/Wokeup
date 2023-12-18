using Domain.Interface;
using Infrastructure;
using Infrastructure.DTO;
using Infrastructure.Interface;
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
        private readonly IFavoriteRepository favoriteListRepository;
        private readonly IUser user;

        public FavoriteListService(IUser user, IFavoriteRepository favoriteRepository)
        {
            if (user == null)
            {
                throw new ArgumentException("User is null");
            }

            if (favoriteRepository == null)
            {
                throw new ArgumentException("FavoriteRepository is null");
            }

            this.user = user;
            this.favoriteListRepository = favoriteRepository;
        }

        public ServiceStatusResult CreateFavoriteList(IFavoriteList favoriteList)
        {
            bool isAddedSucces = this.user.AddFavoriteList(new FavoriteList(favoriteList.name));

            if (isAddedSucces == false)
            {
                return ServiceStatusResult.Failure("Error", $"Favorite list with name: {favoriteList.name} already exsit, please try other name!");
            }

            bool isAddedToDatabase = this.favoriteListRepository.AddNewFavoriteList(new FavoriteListDTO(favoriteList.name), new UserDTO(this.user.name));

            if (isAddedToDatabase == false)
            {
                return ServiceStatusResult.Failure("Error", "Can't not added favorite list in database");
            }

            return ServiceStatusResult.Success("Succes", $"Created `{favoriteList.name}` list succesful!");
        }

        public ServiceStatusResult RemoveFavoriteList(IFavoriteList favoriteList)
        {
            if (favoriteList == null)
            {
                throw new ArgumentException("Favorite list null");
            }

            bool isRemoved = user.RemoveFavoriteList(favoriteList);

            if (isRemoved == false)
            {
                return ServiceStatusResult.Failure("Error", "Can't remove favorite list");
            }

            FavoriteListDTO favoriteListDTO = new FavoriteListDTO(favoriteList.name);

            bool isRemovedInDatabase = this.favoriteListRepository.RemoveFavoriteList(favoriteListDTO);
            if (isRemovedInDatabase == false)
            {
                return ServiceStatusResult.Failure("Error", "Can't remove favorite list in database");
            }

            return ServiceStatusResult.Success();
        }

        public IReadOnlyList<IFavoriteList> GetUserFavoriteLists()
        {
            IReadOnlyList<FavoriteListDTO> favoriteListsDto = this.favoriteListRepository.GetAllFavoriteListBaseOnUser(new UserDTO(user.name));

            foreach (FavoriteListDTO favoriteListDto in favoriteListsDto)
            {
                this.user.AddFavoriteList(new FavoriteList(favoriteListDto.name));
            }

            return user.GetFavoriteLists();
        }

        public ServiceStatusResult AddSongToFavoriteList(Song song, IFavoriteList favoriteList)
        {
            if (song == null)
            {
                throw new ArgumentException("Song is null");
            }

            if (favoriteList == null)
            {
                throw new ArgumentException("Favorite list is null");
            }

            SongDTO songDto = new SongDTO(song.name);
            FavoriteListDTO favoriteListDto = new FavoriteListDTO(favoriteList.name);

            bool isSongAdded = favoriteList.AddSongToFavoriteList(song);

            if (isSongAdded == false)
            {
                return ServiceStatusResult.Failure("Info", $"Song has already been added to {favoriteList.name} list, select another list!");
            }

            bool isAddedToDatabase = this.favoriteListRepository.AddSongTofavorietList(songDto, favoriteListDto);
            if (isAddedToDatabase == false)
            {
                return ServiceStatusResult.Failure("Error", "Can't not add song into favorite list in database");
            }

            return ServiceStatusResult.Success();
        }

        public ServiceStatusResult RemoveSongInFavoriteList(Song song, IFavoriteList favoriteList)
        {
            if (song == null)
            {
                throw new ArgumentException("Song is null");
            }

            if (favoriteList == null)
            {
                throw new ArgumentException("Favorite list is null");
            }

            bool isRemoved = favoriteList.RemoveSongInFavoriteList(song);

            if (isRemoved == false)
            {
                return ServiceStatusResult.Failure("Error", "Removed song does not exist in the favorite list");
            }

            bool isRemoveInDatabase = favoriteListRepository.RemoveSongInFavoriteList(new SongDTO(song.name), new FavoriteListDTO(favoriteList.name));
            if (isRemoveInDatabase == false)
            {
                return ServiceStatusResult.Failure("Error", "Can't remove song in favorite list in databse");
            }

            return ServiceStatusResult.Success();
        }
    }
}
