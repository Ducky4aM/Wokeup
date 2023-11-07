using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class SongDTO
    {
        public int songId { get; private set; }
        public string songName { get; private set; }
        public string songImage { get; private set; }
        public int songListened { get; private set; }
        public GenreDTO genreDto { get; private set; }
        public ArtistDTO artistDto { get; private set; }
       
        public SongDTO(int songid , string songName, string songImage, int songListened, GenreDTO genreDto, ArtistDTO artistDto) {
            this.songId = songid;
            this.songName = songName;
            this.songImage = songImage;
            this.songListened = songListened;
            this.genreDto = genreDto;
            this.artistDto = artistDto;
        }

        public SongDTO(int songid)
        {
            this.songId = songid;
        }
    }
}
