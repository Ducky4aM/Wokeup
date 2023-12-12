using Domain.Interface;
using Domain.Service.Interface;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class SuggestSongs
    {
        private List<Song> songs = new List<Song>();

        private SongService songService;

        public SuggestSongs(SongService songService) 
        { 
            this.songService = songService;
            songs = songService.GetAllSongs().ToList();
        }

        public IReadOnlyList<Song> GetSuggestSongs(IUser user, IGetSongsStrategy SongsStrategy)
        {
            return SongsStrategy.GetSongs(user, songs);
        }
    }
}
