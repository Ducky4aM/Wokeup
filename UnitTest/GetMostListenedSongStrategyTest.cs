using Domain.Service;
using Domain;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Mock;
using Domain.Interface;
using MySqlX.XDevAPI.Common;
using System.Xml.Linq;
using Infrastructure.DTO;

namespace UnitTest
{
    public class GetMostListenedSongStrategyTest
    {
        [Fact]
        public void GetMostListenedSongStrategyWithUserParamIsNullAndThrowArgumentException()
        {
            //Arrange
            GetMostListenedSongsStrategy getMostListenedSongsStrategy = new GetMostListenedSongsStrategy();
            List<Song> songs = new List<Song>();

            //Act
            Action act = () => getMostListenedSongsStrategy.GetSongs(null, songs);

            //Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal(ex.Message,"User is null");
        }

        [Fact]
        public void GetMostListenedSongStrategyWithSongListEmptyAndThrowArgumentException()
        {
            //Arrange

            GetMostListenedSongsStrategy getMostListenedSongsStrategy = new GetMostListenedSongsStrategy();
            List<Song> songs = new List<Song>();
            IUser userMock = new UserMock();

            //Act
            Action act = () => getMostListenedSongsStrategy.GetSongs(userMock, songs);

            //Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal(ex.Message, "Song list can't be empty");
        }

        [Fact]
        public void GetMostListenedSongStrategyThatReturnAListWithMostListenedSongOnTop()
        {
            //Arrange
            GetMostListenedSongsStrategy getMostListenedSongsStrategy = new GetMostListenedSongsStrategy();
            List<Song> songs = new List<Song>() {
                new Song("Song1","image",100, new Genre("Hiphop"),new Artist("Artist1"), new DateTime()),
                new Song("Song2","image",300, new Genre("Hiphop"),new Artist("Artist1"), new DateTime()),
                new Song("Song3","image",1, new Genre("Hiphop"), new Artist("Artist1"), new DateTime()),
                new Song("Song4","image",500, new Genre("Hiphop"), new Artist("Artist1"), new DateTime()),
            };
            IUser userMock = new UserMock();

            //Act
            IReadOnlyList<Song> result = getMostListenedSongsStrategy.GetSongs(userMock, songs);

            //Assert
            Assert.Equal(result[0].name, "Song4");
            Assert.Equal(result[0].listened, 500);
            Assert.Equal(result[1].name, "Song2");
            Assert.Equal(result[1].listened, 300);
            Assert.Equal(result[2].name, "Song1");
            Assert.Equal(result[2].listened, 100);
            Assert.Equal(result[3].name, "Song3");
            Assert.Equal(result[3].listened, 1);
        }
    }
}