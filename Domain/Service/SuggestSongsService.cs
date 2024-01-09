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
    public class SuggestSongsService
    {
        private List<Song> songs = new List<Song>();

        private ISongService songService;

        public SuggestSongsService(ISongService songService) 
        {
            if (songService == null)
            {
                throw new ArgumentException("songService is null");
            }

            this.songService = songService;
        }

        public IReadOnlyList<Song>GetSuggestSongs(IUser user, IGetSongsStrategy getSongsStrategy)
        {
            if (user == null)
            {
                throw new ArgumentException("Argument user is null");
            }

            if (getSongsStrategy == null)
            {
                throw new ArgumentException("Argument getSongsStrategy is null");
            }

            songs = songService.GetAllSongs().ToList();

            if (songs.Count() == 0)
            {
                throw new NullReferenceException("There is no song for suggestion");
            }

            return getSongsStrategy.GetSongs(user, songs);
        }
    }
}
