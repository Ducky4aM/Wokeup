using Infrastructure;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MusicApp
    {
        private List<Song> topListenedSongs = new List<Song>();
        private SongRepository songRepository = new SongRepository();

        public MusicApp(User user) {
            IReadOnlyList<SongDTO> listSongsDto =  songRepository.GetAllSong();

            foreach (SongDTO songDto in listSongsDto )
            {
                Song song = new Song(songDto.songName, songDto.songImage, songDto.songListened);
                
                topListenedSongs.Add(song);
            }
        }

        public IReadOnlyList<Song> GetTopListenedSongs { 
            get {  return this.topListenedSongs; } 
        }
    }
}
