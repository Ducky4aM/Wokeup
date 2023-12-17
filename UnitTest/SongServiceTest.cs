using Domain;
using Domain.Interface;
using Domain.Service;
using Infrastructure.DTO;
using Infrastructure.Interface;
using UnitTest.Mock;

namespace UnitTest
{
    public class SongServiceTest
    {


        [Fact]
        public void GetAllSongThatReturnAllsongs()
        {
            List<SongDTO> songDto = new List<SongDTO>(){
                new SongDTO("Song1", "SongImage1", 100, new GenreDTO("Hiphop"), new ArtistDTO("ArtistName1"),new DateTime()),
                new SongDTO("Song2", "SongImage2", 100, new GenreDTO("Rap"), new ArtistDTO("ArtistName2"), new DateTime()),
                new SongDTO("Song3", "SongImage3", 100, new GenreDTO("Dance"), new ArtistDTO("ArtistName3"), new DateTime()),
                new SongDTO("Song4", "SongImage4", 100, new GenreDTO("Hiphop"), new ArtistDTO("ArtistName1"), new DateTime()),
            };

            //Arrange
            ISongRepository songRepositoryMock = new SongRepositoryMock(songDto);
            SongService songService = new SongService(songRepositoryMock);

            //Act
            IReadOnlyList<Song> songs = songService.GetAllSongs();

            //Assert
            Assert.NotNull(songs);
            Assert.Equal(4, songs.Count);
            Assert.Equal("Song1", songs[0].name);
            Assert.Equal("Song2", songs[1].name);
            Assert.Equal("Song3", songs[2].name);
            Assert.Equal("Song4", songs[3].name);
        }

        [Fact]
        public void GetAllSongThatReturnEmptyListSong()
        {
            //Arrange
            ISongRepository songRepositoryMock = new SongRepositoryMock(new List<SongDTO>());
            SongService songService = new SongService(songRepositoryMock);

            //Act
            IReadOnlyList<Song> songs = songService.GetAllSongs();

            //Assert
            Assert.Equal(0, songs.Count);
        }

        [Fact]
        public void GetSongsBasOnGenreThatReurnAListOfSongWithGenreHipHop()
        {
            List<SongDTO> songDtos = new List<SongDTO>(){
                new SongDTO("Song1", "SongImage1", 100, new GenreDTO("Hiphop"), new ArtistDTO("ArtistName1"),new DateTime()),
                new SongDTO("Song2", "SongImage2", 100, new GenreDTO("Hiphop"), new ArtistDTO("ArtistName2"),new DateTime()),
                new SongDTO("Song3", "SongImage3", 100, new GenreDTO("Hiphop"), new ArtistDTO("ArtistName3"),new DateTime()),
                new SongDTO("Song4", "SongImage4", 100, new GenreDTO("Hiphop"), new ArtistDTO("ArtistName1"),new DateTime()),
            };

            //Arrange
            ISongRepository songRepositoryMock = new SongRepositoryMock(songDtos);
            SongService songService = new SongService(songRepositoryMock);
            Genre genre = new Genre("Hiphop");

            //Act
            IReadOnlyList<Song> songs = songService.GetSongsBaseOnGenre(genre);

            //Assert
            Assert.NotNull(songs);

            // hier geen foreach gebruiken
            foreach (Song song in songs)
            {
                Assert.Equal(song.genre.name, genre.name);
            }
        }

        [Fact]
        public void GetSongsBasOnGenreThatThatGenreIsNullAndThrowArgumentException()
        {
            //Arrange
            ISongRepository songRepositoryMock = new SongRepositoryMock();
            SongService songService = new SongService(songRepositoryMock);

            //act
            Action act = () => songService.GetSongsBaseOnGenre(null);

            //assert
            ArgumentException ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Genre is null", ex.Message);
        }

        [Fact]
        public void GetSongsFromFavoriteListShouldReurnListOfSongInThatFavoriteList()
        {
            List<SongDTO> songDtos = new List<SongDTO>(){
                new SongDTO("Song1", "SongImage1", 100, new GenreDTO("Hiphop"), new ArtistDTO("ArtistName1"),new DateTime()),
                new SongDTO("Song2", "SongImage2", 100, new GenreDTO("Rap"), new ArtistDTO("ArtistName2"), new DateTime()),
                new SongDTO("Song3", "SongImage3", 100, new GenreDTO("Dance"), new ArtistDTO("ArtistName3"), new DateTime()),
                new SongDTO("Song4", "SongImage4", 100, new GenreDTO("Hiphop"), new ArtistDTO("ArtistName1"), new DateTime()),
                new SongDTO("Song5", "SongImage5", 100, new GenreDTO("Hiphop"), new ArtistDTO("ArtistName1"), new DateTime()),
            };

            List<Song> songs = new List<Song>(){
                new Song("Song1", "SongImage1", 100, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime()),
                new Song("Song2", "SongImage2", 100, new Genre("Rap"), new Artist("ArtistName2"), new DateTime()),
                new Song("Song3", "SongImage3", 100, new Genre("Dance"), new Artist("ArtistName3"), new DateTime()),
                new Song("Song4", "SongImage4", 100, new Genre("Hiphop"), new Artist("ArtistName1"), new DateTime()),
            };

            //Arrange
            IFavoriteList favoriteListMock = new FavoriteListMock(songs);
            ISongRepository songRepositoryMock = new SongRepositoryMock(songDtos);
            SongService songService = new SongService(songRepositoryMock);

            //Act
            IReadOnlyList<Song> result = songService.GetSongsFromFavoriteList(favoriteListMock);

            //Assert
            Assert.Equal(4, result.Count);
            Assert.Equal("Song1", result[0].name);
            Assert.Equal("Song2", result[1].name);
            Assert.Equal("Song3", result[2].name);
            Assert.Equal("Song4", result[3].name);
        }
    }
}