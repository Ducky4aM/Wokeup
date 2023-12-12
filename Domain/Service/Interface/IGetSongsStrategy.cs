using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Interface
{
    public interface IGetSongsStrategy
    {
        IReadOnlyList<Song> GetSongs(IUser user,List<Song> songs);
    }
}
