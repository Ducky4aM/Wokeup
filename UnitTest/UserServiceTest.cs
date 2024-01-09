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
    public class UserServiceTest
    {
        [Fact]
        public void UserSeviceContructorThrowArgumentNullExceptionWhenUserIsNull()
        {
            //arrage
            IUser user = null;
            IUserRepository userRepository = new UserRepository();

            //act
            Action act = () => new UserService(user, userRepository);
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(act);

            //assert
            Assert.Equal("Value cannot be null. (Parameter 'User is null')", ex.Message);
        }

        [Fact]
        public void UserSeviceContructorThrowArgumentNullExceptionWhenIUserRepositoryIsNull()
        {
            //arrage 
            IUser user = new UserMock();
            IUserRepository userRepository = null;

            //act
            Action act = () => new UserService(user, userRepository);
            ArgumentException ex = Assert.Throws<ArgumentNullException>(act);

            //assert
            Assert.Equal("Value cannot be null. (Parameter 'UserRepository is null')", ex.Message);
        }

        [Fact]
        public void UserServiceContructorWhenArgumentIsValid()
        {
            // Arrange
            IUser user = new UserMock();
            IUserRepository userRepository = new UserRepositoryMock();

            // Act
            IUserService userService = new UserService(user, userRepository);

            // Assert
            Assert.NotNull(userService);
            Assert.NotNull(userRepository);
        }

        [Fact]
        public void UserServiceSetUserPreferGenreWithNullGenreThrowArgumentException()
        {
            //arrage
            IUser user = new UserMock();
            IUserRepository userRepository = new UserRepositoryMock();

            //act
            IUserService userService = new UserService(user, userRepository);
            Action act = () => userService.SetUserPreferGenre(null);

            //assert
            ArgumentException ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Genre is null", ex.Message);
        }

        [Fact]
        public void UserServiceSetUserPreferGenreIsAddedToUserFalseAndReturnServiceStatusResultFailure()
        {
            //arrage
            IUser user = new UserMock(false);
            IUserRepository userRepository = new UserRepositoryMock();

            //act
            IUserService userService = new UserService(user, userRepository);
            ServiceStatusResult serviceStatusResult = userService.SetUserPreferGenre(new Genre("Hiphop"));

            //assert
            Assert.False(serviceStatusResult.isSuccess);
            Assert.Equal("Error", serviceStatusResult.messageTitle);
            Assert.Equal("Can't added prefer genre", serviceStatusResult.messageText);
        }

        [Fact]
        public void UserServiceSetUserPreferGenreIsAddedToDataBaseFalseAndReturnServiceStatusResultFailure()
        {
            //arrage
            IUser user = new UserMock(true);
            IUserRepository userRepository = new UserRepositoryMock(false);

            //act
            IUserService userService = new UserService(user, userRepository);
            ServiceStatusResult serviceStatusResult = userService.SetUserPreferGenre(new Genre("Hiphop"));

            //assert
            Assert.False(serviceStatusResult.isSuccess);
            Assert.Equal("Error", serviceStatusResult.messageTitle);
            Assert.Equal("Can't added prefer genre in database", serviceStatusResult.messageText);
        }

        [Fact]
        public void UserServiceSetUserPreferGenreAd0dedSuccessAndReuturnServiceStatusResultSuccess()
        {
            Genre genre = new Genre("Hiphop");
            //arrage
            IUser user = new UserMock(true, genre);
            IUserRepository userRepository = new UserRepositoryMock(true);

            //act
            IUserService userService = new UserService(user, userRepository);
            ServiceStatusResult serviceStatusResult = userService.SetUserPreferGenre(genre);

            //assert
            Assert.True(serviceStatusResult.isSuccess);
            Assert.Same(genre, user.GetPreferGenre());
            Assert.Equal(genre.name, user.GetPreferGenre().name);
        }

        [Fact]
        public void IsUserHaveSongInFavoriteListThatListOfFavoriteListFromUserCountIsNullReturnFalse()
        {
            //arrage
            IUser user = new UserMock(new List<IFavoriteList>());
            IUserRepository userRepository = new UserRepositoryMock();

            //act
            IUserService userService = new UserService(user, userRepository);
            bool result = userService.IsUserHaveSongInFavoriteList();

            //assert
            Assert.False(result);
        }

        [Fact]
        public void IsUserHaveSongInFavoriteListThatListOfFavoriteListFromUserCountIsNotNullAndHaveSongInFavoriteListThatReturnTrue()
        {
            IFavoriteList favoriteList = new FavoriteListMock(new List<Song>() {
                new Song("song 1")
            });

            List<IFavoriteList> favoriteLists = new List<IFavoriteList>() {
                favoriteList
            };

            //arrage
            IUser user = new UserMock(favoriteLists);
            IUserRepository userRepository = new UserRepositoryMock();

            //
            IUserService userService = new UserService(user, userRepository);
            bool result = userService.IsUserHaveSongInFavoriteList();

            //assert
            Assert.True(result);
        }

        [Fact]
        public void IsUserHaveSongInFavoriteListThatListOfFavoriteListFromUserCountIsNotNullAndEptySongInTheListThatReturnFalse()
        {
            List<IFavoriteList> favoriteLists = new List<IFavoriteList>() {
                new FavoriteList("list 1")
            };

            //arrage
            IUser user = new UserMock(favoriteLists);
            IUserRepository userRepository = new UserRepositoryMock();

            //act
            IUserService userService = new UserService(user, userRepository);
            bool result = userService.IsUserHaveSongInFavoriteList();

            //assert
            Assert.False(result);
        }

        [Fact]
        public void GetSuggestGenreForUserThatUserFavoriteListIsNullAndThrowNullReferenceException()
        {
            //arrage
            IUser user = new UserMock(null);
            IUserRepository userRepository = new UserRepositoryMock();

            //act
            UserService userService = new UserService(user, userRepository);

            Action act = () => userService.GetSuggestGenreForUser();
            NullReferenceException ex = Assert.Throws<NullReferenceException>(act);

            //assert
            Assert.Equal("userFavoriteLists is null", ex.Message);
        }

        [Fact]
        public void GetSuggestGenreForUserThatUserHavePreferGenreAndReturnListOfGenreWithPreferGenreAtLastPositionOfTheListAndTheMostCommonGenreFromFavoriteListOnTop()
        {
            //arrage
            IFavoriteList favoriteList = new FavoriteListMock(new List<Song>() {
                new Song("song 1", "image",100, new Genre("Rap"), new Artist("artist 1"), new DateTime()),
                new Song("song 2", "image",100, new Genre("Rap"), new Artist("artist 1"), new DateTime()),
                new Song("song 3", "image",100, new Genre("HipHop"), new Artist("artist 1"), new DateTime()),
                new Song("song 4", "image",100, new Genre("Rap"), new Artist("artist 1"), new DateTime()),
                new Song("song 5", "image",100, new Genre("HipHop"), new Artist("artist 1"), new DateTime()),
            });

            List<IFavoriteList> favoriteLists = new List<IFavoriteList>() {
                favoriteList
            };

            IUser user = new UserMock(favoriteLists,new Genre("Pop"));
            IUserRepository userRepository = new UserRepositoryMock();

            //
            IUserService userService = new UserService(user, userRepository);
            List<Genre> genres = userService.GetSuggestGenreForUser();

            //assert
            Assert.Equal(3, genres.Count());
            Assert.Equal("Rap", genres[0].name);
            Assert.Equal("HipHop", genres[1].name);
            Assert.Equal("Pop", genres[2].name);
        }

        [Fact]
        public void GetSuggestGenreForUserThatUserPreferGenreIsNullAndReturnListOfGenreAndTheMostCommonGenreFromFavoriteListOnTop()
        {
            //arrage
            IFavoriteList favoriteList = new FavoriteListMock(new List<Song>() {
                new Song("song 1", "image",100, new Genre("Dance"), new Artist("artist 1"), new DateTime()),
                new Song("song 2", "image",100, new Genre("Dance"), new Artist("artist 1"), new DateTime()),
                new Song("song 3", "image",100, new Genre("HipHop"), new Artist("artist 1"), new DateTime()),
                new Song("song 4", "image",100, new Genre("HipHop"), new Artist("artist 1"), new DateTime()),
                new Song("song 5", "image",100, new Genre("HipHop"), new Artist("artist 1"), new DateTime()),
            });

            List<IFavoriteList> favoriteLists = new List<IFavoriteList>() {
                favoriteList
            };

            IUser user = new UserMock(favoriteLists);
            IUserRepository userRepository = new UserRepositoryMock();

            //
            IUserService userService = new UserService(user, userRepository);
            List<Genre> genres = userService.GetSuggestGenreForUser();

            //assert
            Assert.Equal(2, genres.Count());
            Assert.Equal("HipHop", genres[0].name);
            Assert.Equal("Dance", genres[1].name);
        }
    }
}
