using Domain;
using Domain.Interface;
using Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Mock
{
    public class GetMostListenedSongStrategyMock : IGetSongsStrategy
    {
        private readonly List<Song> songsMock;

        public GetMostListenedSongStrategyMock(List<Song> songs)
        {
            this.songsMock = songs; 
        }

        public IReadOnlyList<Song> GetSongs(IUser user, List<Song> songs)
        {
            return songsMock.AsReadOnly();
        }
    }
}
