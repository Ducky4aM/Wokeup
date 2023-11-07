using Infrastructure.DTO;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class SongService
    {
        private SongRepository SongRepository;

        public SongService()
        {
            this.SongRepository = new SongRepository();
        }

        public IReadOnlyList<Song> GetTopSongs()
        {
            IReadOnlyList<SongDTO> listSongsDto = this.SongRepository.GetTopSongs();
            List<Song> songs = new List<Song>();

            foreach (SongDTO songDto in listSongsDto)
            {
                Song song = new Song(
                    songDto.songId, 
                    songDto.songName, 
                    songDto.songImage, 
                    songDto.songListened, 
                    new Genre(songDto.genreDto.name),
                    new Artist(songDto.artistDto.name)
                    );

                songs.Add(song);
            }

            return songs.AsReadOnly();
        }

        public IReadOnlyList<Song> GetSongsBaseOnGenre(Genre genre)
        {
            List<Song> songs = new List<Song>();
            IReadOnlyList<SongDTO> songsDto = this.SongRepository.GetSongsBaseOnGenre(new GenreDTO(genre.name));

            foreach (SongDTO songDto in songsDto)
            {
                songs.Add(
                    new Song(songDto.songId,
                    songDto.songName,
                    songDto.songImage,
                    songDto.songListened,
                    new Genre(songDto.genreDto.name),
                    new Artist(songDto.artistDto.name))
                    );
            }


            return songs.AsReadOnly();
        }


    }
}
