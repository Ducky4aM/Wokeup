using Infrastructure;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FavoriteList
    {
        public string name {  get; private set; }

        public int id { get; private set; }

        private List<Song> songs = new List<Song>();

        private SongRepository songRepository = new SongRepository();
        private FavoriteListRepository favoriteListRepository = new FavoriteListRepository();

        public FavoriteList(string name)
        {
            this.name = name;
        }

        public FavoriteList(int id, string name) 
        {
            this.name = name;
            this.id = id;
        }

        public IReadOnlyList<Song> GetSongs() {
            FavoriteListDTO favoriteListDto = new FavoriteListDTO(this.id, this.name);

            IReadOnlyList<SongDTO> favoriteListSongDtos = this.songRepository.GetSongFromFavoriteList(favoriteListDto);

            if (favoriteListSongDtos.Count > 0)
            {
                this.songs.Clear();

                foreach (SongDTO songDto in favoriteListSongDtos)
                {
                    this.songs.Add(new Song(songDto.songId,songDto.songName, songDto.songImage, songDto.songListened));
                }
            }

            return this.songs.AsReadOnly();
        }

        public bool AddSongToFavoriteList(Song song)
        {
            SongDTO songDto = new SongDTO(song.id);
            FavoriteListDTO favoriteList = new FavoriteListDTO(this.id, this.name);
            IReadOnlyList<Song> songlist = this.GetSongs();

            bool isSongExistInList = songlist.Any(songCheck => songCheck.id == song.id);


            if (isSongExistInList == true)
            {
                return false;
            }

            this.favoriteListRepository.AddSongTofavorietList(songDto, favoriteList);
            this.songs.Add(song);

            return true;
        }

        public bool RemoveSongFromFavoriteList(Song song)
        {
            bool isRemoved = favoriteListRepository.RemoveSongFomFavoriteList(new SongDTO(song.id), new FavoriteListDTO(this.id, this.name));

            if (isRemoved == false)
            {
                return false;
            }

            this.songs.Remove(song);
            return true;

        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
