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

        public FavoriteListService(User user)
        {
            this.user = user;
            this.favoriteListRepository = new FavoriteListRepository();
            this.songRepository = new SongRepository();
        }

        public ServiceStatusJob CreateFavoriteList(string name)
        {
            if (name == "")
            {
                return new ServiceStatusJob(false,"Warning",$"field name can't be empty!");
            }

            if (this.CheckFavoriteListExistsForUser(name) == true)
            {
                return new ServiceStatusJob(false, "Warning", $"Favorite list with name: {name} already exsit, please try other name!");
            }

            FavoriteList newFavoriteList = new FavoriteList(name);

            //adding to database
            bool isAdded = this.favoriteListRepository.AddNewFavoriteList(new FavoriteListDTO(name), new UserDTO(this.user.id));

            if (isAdded == false)
            {
                return new ServiceStatusJob(true, "Error", "Something when wrong with server!");
            }

            this.user.AddFavoriteList(newFavoriteList);

            return new ServiceStatusJob(true,"Succes", $"Created {newFavoriteList.name} list succesful!");
        }

        private bool CheckFavoriteListExistsForUser(string name)
        {
            return user.GetFavoriteLists().Any(favoritelist => favoritelist.name.Equals(name));
        }

        public ServiceStatusJob RemoveFavoriteList(FavoriteList? favoriteList)
        {
            if (favoriteList == null)
            {
                return new ServiceStatusJob(false, "Error", "Select favorite list to remove");
            }

            FavoriteListDTO favoriteListDTO = new FavoriteListDTO(favoriteList.id, favoriteList.name);
            bool isRemoved = this.favoriteListRepository.RemoveFavoriteList(favoriteListDTO);

            if (isRemoved == false)
            {
                return new ServiceStatusJob(false,"Error", "Something when wrong with server!");
            }

            user.RemoveFavoriteList(favoriteList);
            return new ServiceStatusJob(true);
        }

        public IReadOnlyList<FavoriteList> GetUserFavoriteLists()
        {
            IReadOnlyList<FavoriteListDTO> favoriteListsDto = this.favoriteListRepository.GetAllFavoriteListBaseOnUser(new UserDTO(user.id));
            List<FavoriteList> favoriteLists = new List<FavoriteList>();

            foreach (FavoriteListDTO favoriteListDto in favoriteListsDto)
            {
                favoriteLists.Add(new FavoriteList(favoriteListDto.id, favoriteListDto.name));
            }

            user.UpdateFavoriteList(favoriteLists);

            return user.GetFavoriteLists();
        }

        public ServiceStatusJob getSongsFromFavoriteList(FavoriteList? favoriteList)
        {
            if (favoriteList == null)
            {
                return new ServiceStatusJob(false, "Warning", "There no favorite list selected!");
            }

            FavoriteListDTO favoriteListDto = new FavoriteListDTO(favoriteList.id, favoriteList.name);
            IReadOnlyList<SongDTO> songsDto = this.songRepository.GetSongFromFavoriteList(favoriteListDto);
            List<Song> songs = new List<Song>();

            foreach (SongDTO songDto in songsDto)
            {
                songs.Add(
                    new Song(
                        songDto.songId,
                        songDto.songName,
                        songDto.songImage,
                        songDto.songListened,
                        new Genre(songDto.genreDto.name),
                        new Artist(songDto.artistDto.name)
                        )
                    );
            }

            //update song list of favoriteList
            //favoriteList.UpdateListSong(songs);

            return new ServiceStatusJob(true);
        }

        public ServiceStatusJob AddSongToFavoriteList(Song song, FavoriteList favoriteList)
        {
            SongDTO songDto = new SongDTO(song.id);
            FavoriteListDTO favoriteListDto = new FavoriteListDTO(favoriteList.id, favoriteList.name);

            this.favoriteListRepository.AddSongTofavorietList(songDto, favoriteListDto);

            bool isSongAdded = favoriteList.AddSongToFavoriteList(song);

            if (isSongAdded == false )
            {
                return new ServiceStatusJob(false, "Info", $"Song has already been added to {favoriteList.name} list, select another list!");
            }

            return new ServiceStatusJob(true);
        }

        public ServiceStatusJob removeSongInFavoriteList(Song? song, FavoriteList favoriteList)
        {
            if (song == null)
            {
                return new ServiceStatusJob(false, "error", "No song selected!");
            }

            int test = song.id;

            //remove in database
            bool isRemoved = favoriteListRepository.RemoveSongFomFavoriteList(new SongDTO(song.id), new FavoriteListDTO(favoriteList.id, favoriteList.name));

            if (isRemoved == false)
            {
                return new ServiceStatusJob(false, "error", "Something when wrong with server!");
            }

            favoriteList.RemoveSong(song);

            return new ServiceStatusJob(true);
        }
    }
}
