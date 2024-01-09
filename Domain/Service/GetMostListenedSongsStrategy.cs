using Domain.Interface;
using Domain.Service.Interface;
using Domain.Service.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class GetMostListenedSongsStrategy : IGetSongsStrategy
    {
        public IReadOnlyList<Song> GetSongs(IUser user,List<Song> songs)
        {
            if (user == null)
            {
                throw new ArgumentException("User is null");
            }

            if (songs.Count() == 0)
            {
                throw new ArgumentException("Song list can't be empty");
            }

            songs.Sort(new SongListenedComparer());

            return songs.AsReadOnly();
        }
    }
}
