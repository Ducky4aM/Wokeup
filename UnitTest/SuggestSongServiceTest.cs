using Domain;
using Domain.Interface;
using Domain.Service;
using Domain.Service.Interface;
using Infrastructure;
using Infrastructure.DTO;
using Infrastructure.Interface;
using UnitTest.Mock;

namespace UnitTest
{
    public class SuggestSongServiceTest
    {
        [Fact]
        public void SuggestSongServiceContructWithSongServiceAsNullThisThrowArgumentException()
        {
            //act
            Action act = () => new SuggestSongsService(null);

            //assert
            ArgumentException ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("songService is null", ex.Message);
        }

        [Fact]
        public void SuggestSongServiceGetSuggestSongsWithArgumentUseIsNullThisThrowArgumentException()
        {
            //arrage
            SongServiceMock songServiceMock = new SongServiceMock();
            SuggestSongsService suggestSongsService = new SuggestSongsService(songServiceMock);

            //act
            Action act = () => suggestSongsService.GetSuggestSongs(null, new GetMostListenedSongsStrategy());

            //assert
            ArgumentException ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Argument user is null", ex.Message);
        }


        [Fact]
        public void SuggestSongServiceGetSuggestSongsWithArgumentGetSongStrategyIsNullThisThrowArgumentException()
        {
            //arrage
            SongServiceMock songServiceMock = new SongServiceMock();
            SuggestSongsService suggestSongsService = new SuggestSongsService(songServiceMock);
            UserMock userMock = new UserMock();

            //act
            Action act = () => suggestSongsService.GetSuggestSongs(userMock, null);

            //assert
            ArgumentException ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Argument getSongsStrategy is null", ex.Message);
        }


        [Fact]
        public void SuggestSongServiceGetSuggestSongsWithGetSongAllFromSongSeriviceReturnEmptyListOfSongThisThrowNullReferenceException()
        {
            //arrage
            SongServiceMock songServiceMock = new SongServiceMock(new List<Song>());
            SuggestSongsService suggestSongsService = new SuggestSongsService(songServiceMock);
            UserMock userMock = new UserMock();

            //act
            Action act = () => suggestSongsService.GetSuggestSongs(userMock, new GetMostListenedSongsStrategy());

            //assert
            NullReferenceException ex = Assert.Throws<NullReferenceException>(act);
            Assert.Equal("There is no song for suggestion", ex.Message);
        }

        [Fact]
        public void SuggestSongsServiceGetSuggestSongsWithIGetSongStrategyAsGetMostListenedSongStrategy()
        {
            //arrage
            List<Song> songs = new List<Song>() {
                new Song("Song1", "SongImage1", 15, new Genre("Rap"), new Artist("ArtistName2"), new DateTime()),
                new Song("Song2", "SongImage2", 8, new Genre("Dance"), new Artist("ArtistName3"), new DateTime()),
                new Song("Song3", "SongImage3", 500, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime()),
                new Song("Song4", "SongImage4", 10, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime()),
                new Song("Song5", "SongImage5", 1, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime()),
            };

            SongServiceMock songServiceMock = new SongServiceMock(songs);
            UserMock userMock = new UserMock();
            GetMostListenedSongStrategyMock getMostListenedSongStrategyMock = new GetMostListenedSongStrategyMock(new List<Song>(){
                new Song("Song3", "SongImage3", 500, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime()),
                new Song("Song1", "SongImage1", 15, new Genre("Rap"), new Artist("ArtistName2"), new DateTime()),
                new Song("Song4", "SongImage4", 10, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime()),
                new Song("Song2", "SongImage2", 8, new Genre("Dance"), new Artist("ArtistName3"), new DateTime()),
                new Song("Song5", "SongImage5", 1, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime()),
            });

            SuggestSongsService suggestSongsService = new SuggestSongsService(songServiceMock);
            
            //act
            IReadOnlyList<Song> result = suggestSongsService.GetSuggestSongs(userMock, getMostListenedSongStrategyMock);

            //arrange
            Assert.Equal(result[0].name, songs[2].name);
            Assert.Equal(500, result[0].listened);            
            Assert.Equal(result[1].name, songs[0].name);
            Assert.Equal(15, result[1].listened);            
            Assert.Equal(result[2].name, songs[3].name);
            Assert.Equal(10, result[2].listened);
            Assert.Equal(result[3].name, songs[1].name);
            Assert.Equal(8, result[3].listened);
            Assert.Equal(result[4].name, songs[4].name);
            Assert.Equal(1, result[4].listened);
        }

        [Fact]
        public void SuggestSongsServiceGetSuggestSongsWithIGetSongStrategyAsGetSongsUserPreferGenreStrategy()
        {
            //arrage
            List<Song> songs = new List<Song>() {
                new Song("Song1", "SongImage1", 15, new Genre("Rap"), new Artist("ArtistName2"), new DateTime()),
                new Song("Song2", "SongImage2", 8, new Genre("Dance"), new Artist("ArtistName3"), new DateTime()),
                new Song("Song3", "SongImage3", 500, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime()),
                new Song("Song4", "SongImage4", 10, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime()),
                new Song("Song5", "SongImage5", 1, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime()),
            };

            Genre userPreferGenre = new Genre("Hiphop");
            SongServiceMock songServiceMock = new SongServiceMock(songs);
            UserMock userMock = new UserMock(true,userPreferGenre);

            GetMostListenedSongStrategyMock getMostListenedSongStrategyMock = new GetMostListenedSongStrategyMock(new List<Song>(){
                new Song("Song3", "SongImage3", 500, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime()),
                new Song("Song4", "SongImage4", 10, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime()),
                new Song("Song5", "SongImage5", 1, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime()),
                new Song("Song1", "SongImage1", 15, new Genre("Rap"), new Artist("ArtistName2"), new DateTime()),
                new Song("Song2", "SongImage2", 8, new Genre("Dance"), new Artist("ArtistName3"), new DateTime()),

            });

            SuggestSongsService suggestSongsService = new SuggestSongsService(songServiceMock);

            //act
            IReadOnlyList<Song> result = suggestSongsService.GetSuggestSongs(userMock, getMostListenedSongStrategyMock);

            //arrange
            Assert.Equal(userPreferGenre.name, result[0].genre.name);
            Assert.Equal(500, result[0].listened);
            Assert.Equal(userPreferGenre.name, result[1].genre.name);
            Assert.Equal(10, result[1].listened);
            Assert.Equal(userPreferGenre.name, result[2].genre.name);
            Assert.Equal(1, result[2].listened);
            Assert.NotEqual(userPreferGenre.name, result[3].genre.name);
            Assert.NotEqual(userPreferGenre.name, result[4].genre.name);
        }


        [Fact]
        public void SuggestSongsServiceGetSuggestSongsWithIGetSongStrategyAsGetSongsSuggestToUserStrategy()
        {
            //arrage
            DateTime Today = new DateTime(2023, 12, 23);

            List<Song> songs = new List<Song>() {
                new Song("Song1", "SongImage1", 50000, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime(2022,2, 20)),
                new Song("Song4", "SongImage4", 10, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime(2023,12, 21)),
                new Song("Song5", "SongImage5", 10000, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime(2022,12, 20)),
                new Song("Song3", "SongImage3", 500, new Genre("Hiphop"), new Artist("ArtistName1"),new DateTime(2023,12, 20)),
            };

            Genre userPreferGenre = new Genre("Hiphop");
            SongServiceMock songServiceMock = new SongServiceMock(songs);
            UserMock userMock = new UserMock(true);

            GetMostListenedSongStrategyMock getMostListenedSongStrategyMock = new GetMostListenedSongStrategyMock(new List<Song>(){
                new Song("Song4", "SongImage4", 10, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime(2023,12, 21)), 
                new Song("Song3", "SongImage3", 500, new Genre("Hiphop"), new Artist("ArtistName1"),new DateTime(2023,12, 20)),
                new Song("Song1", "SongImage1", 50000, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime(2022,2, 20)),
                new Song("Song5", "SongImage5", 10000, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime(2022,12, 20)),
            });

            SuggestSongsService suggestSongsService = new SuggestSongsService(songServiceMock);

            //act
            IReadOnlyList<Song> result = suggestSongsService.GetSuggestSongs(userMock, getMostListenedSongStrategyMock);

            //arrange
            Assert.Equal(songs[1].listened,result[0].listened);
            Assert.Equal(songs[1].releaseAt, result[0].releaseAt);

            Assert.Equal(songs[3].listened, result[1].listened);
            Assert.Equal(songs[3].releaseAt, result[1].releaseAt);

            Assert.Equal(songs[0].listened, result[2].listened);
            Assert.Equal(songs[0].releaseAt, result[2].releaseAt);


            Assert.Equal(songs[2].listened, result[3].listened);
            Assert.Equal(songs[2].releaseAt, result[3].releaseAt);
        }
    }
}
