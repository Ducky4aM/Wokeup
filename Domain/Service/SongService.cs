using Infrastructure.DTO;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Service.Interface;
using Infrastructure.Interface;
using Domain.Interface;

namespace Domain.Service
{
    public class SongService : ISongService
    {
        private ISongRepository songRepository;

        public SongService(ISongRepository songRepository)
        {
            this.songRepository = songRepository;
        }

        public IReadOnlyList<Song> GetAllSongs()
        {
            IReadOnlyList<SongDTO> listSongsDto = this.songRepository.GetAll();
            List<Song> songs = new List<Song>();

            foreach (SongDTO songDto in listSongsDto)
            {
                Song song = new Song(
                    songDto.songName,
                    songDto.songImage,
                    songDto.songListened,
                    new Genre(songDto.genreDto.name),
                    new Artist(songDto.artistDto.name),
                    songDto.releaseAt
                    );

                songs.Add(song);
            }

            return songs.AsReadOnly();
        }

        public IReadOnlyList<Song> GetSongsFromFavoriteList(IFavoriteList favoriteList)
        {
            FavoriteListDTO favoriteListDto = new FavoriteListDTO(favoriteList.name);
            IReadOnlyList<SongDTO> songsDto = this.songRepository.GetSongFromFavoriteList(favoriteListDto);

            foreach (SongDTO songDto in songsDto)
            {
                bool isAddedSong = favoriteList.AddSongToFavoriteList(
                     new Song(
                         songDto.songName,
                         songDto.songImage,
                         songDto.songListened,
                         new Genre(songDto.genreDto.name),
                         new Artist(songDto.artistDto.name),
                         songDto.releaseAt
                         )
                     );

                if (isAddedSong == false)
                {
                    continue;
                }
            }

            return favoriteList.GetSongs();
        }

        public IReadOnlyList<Song> GetSongsBaseOnGenre(Genre genre)
        {
            if (genre == null)
            {
                throw new ArgumentException("Genre is null");
            }

            List<Song> songs = new List<Song>();
            IReadOnlyList<SongDTO> songsDto = this.songRepository.GetSongsBaseOnGenre(new GenreDTO(genre.name));

            foreach (SongDTO songDto in songsDto)
            {
                songs.Add(
                    new Song(
                    songDto.songName,
                    songDto.songImage,
                    songDto.songListened,
                    new Genre(songDto.genreDto.name),
                    new Artist(songDto.artistDto.name),
                    songDto.releaseAt
                  ));
            }


            return songs.AsReadOnly();
        }
    }
}
