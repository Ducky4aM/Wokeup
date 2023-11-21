using Domain.Service.Interface;
using Infrastructure;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class GetSongsUserPreferGenere : IGetSongs
    {
        public IReadOnlyList<Song> GetSongs(User user)
        {
            List<Song> listSongs = new List<Song>();
            SongRepository songRepository = new SongRepository();

            IReadOnlyList<SongDTO> songDtos = songRepository.GetTopListenedSongs();

            foreach (SongDTO songDto in songDtos)
            {
                Song song = new Song(
                   songDto.songId,
                   songDto.songName,
                   songDto.songImage,
                   songDto.songListened,
                   new Genre(songDto.genreDto.name),
                   new Artist(songDto.artistDto.name)
                   );

                listSongs.Add(song);
            }

            listSongs.Sort(new SortSongOnUserPreferGenre(user));

           return listSongs.AsReadOnly();
        }


    }
}
