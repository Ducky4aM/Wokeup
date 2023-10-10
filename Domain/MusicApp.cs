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
        private List<Song> songCollection = new List<Song>();
        private SongRepository songRepository = new SongRepository();

        public MusicApp() {

            List<SongDTO> listSongsDto =  songRepository.GetAllSong();

            foreach (SongDTO songDto in listSongsDto )
            {
                Song song = new Song(songDto.songName, songDto.songImage, songDto.songListened);

                songCollection.Add(song);
            }
        }

        public IReadOnlyList<Song> SongCollection { 
            get {  return this.songCollection; } 
        }

    }
}
