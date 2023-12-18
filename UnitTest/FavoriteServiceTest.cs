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
    public class FavoriteServiceTest
    {
        string favoriteListName = "My favorite";

        [Fact]
        public void CreatFavoriteListThisUserAddFavoriteListFalseReturn()
        {
            //Arrange
            IUser userMock = new UserMock(false);
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock(true);
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);
            IFavoriteList favoriteList = new FavoriteList(favoriteListName);

            //Act
            ServiceStatusResult serviceStatus = favoriteListService.CreateFavoriteList(favoriteList);
            bool isAdded = userMock.AddFavoriteList(new FavoriteList(favoriteListName));

            //Assert
            Assert.False(isAdded);
            Assert.False(serviceStatus.isSuccess);
            Assert.Equal("Error", serviceStatus.messageTitle);
            Assert.Equal($"Favorite list with name: {favoriteListName} already exsit, please try other name!", serviceStatus.messageText);
        }

        [Fact]
        public void CreatFavoriteListThisAddToDataBaseFalseReturn()
        {
            //Arrange
            IUser userMock = new UserMock(true);
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock(false);
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);
            IFavoriteList favoriteList = new FavoriteList(favoriteListName);

            //Act
            ServiceStatusResult serviceStatus = favoriteListService.CreateFavoriteList(favoriteList);

           //Assert
            Assert.Equal ("Error", serviceStatus.messageTitle);
            Assert.Equal ("Can't not added favorite list in database", serviceStatus.messageText);
        }

        [Fact]
        public void CreatFavoriteListThisUserAddFavoriteListTrueReturnAndSuccessfulAdded()
        {
            //Arrange
            IUser userMock = new UserMock("duc", true);
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock(true);
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);
            IFavoriteList favoriteList = new FavoriteList(favoriteListName);

            //Act
            ServiceStatusResult serviceStatus = favoriteListService.CreateFavoriteList(favoriteList);

            //Assert
            Assert.True(serviceStatus.isSuccess);
            Assert.Equal("Succes", serviceStatus.messageTitle);
            Assert.Equal($"Created `{favoriteListName}` list succesful!", serviceStatus.messageText);
        }

        [Fact]
        public void RemoveFavoriteListWithNullFavoriteListThisThrowArgumentException()
        {
            //Arrange
            IUser userMock = new UserMock("duc", true);
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock();
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);

            //act
            Action act = () => favoriteListService.RemoveFavoriteList(null);

            //Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Favorite list null", ex.Message);
        }


        [Fact]
        public void RemoveFavoriteListThatUserRemoveFavoriteListFalseAndReturnServiceStatusResultFailure()
        {
            //Arrange
            IUser userMock = new UserMock(false);
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock();
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);
            FavoriteList favoriteList = new FavoriteList(favoriteListName);

            //act
            ServiceStatusResult serviceStatus = favoriteListService.RemoveFavoriteList(favoriteList);

            //Assert
            Assert.False(serviceStatus.isSuccess);
            Assert.Equal("Error", serviceStatus.messageTitle);
            Assert.Equal("Can't remove favorite list", serviceStatus.messageText);

        }

        [Fact]
        public void RemoveFavoriteListThatIsRemovedInDatabaseFalseReturn()
        {
            //Arrange
            IUser userMock = new UserMock("duc", true);
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock(false);
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);
            FavoriteList favoriteList = new FavoriteList(favoriteListName);

            //act
            ServiceStatusResult serviceStatus = favoriteListService.RemoveFavoriteList(favoriteList);

            //Assert
            Assert.False(serviceStatus.isSuccess);
            Assert.Equal("Error", serviceStatus.messageTitle);
            Assert.Equal("Can't remove favorite list in database", serviceStatus.messageText);
        }


        [Fact]
        public void GetUserFavoriteListThisAddAllFavoriteListToUserAndReturnSameUserFavoriteList()
        {
            //Arrange
            List<FavoriteListDTO> favoriteListDtos = new List<FavoriteListDTO>() {
                new FavoriteListDTO("favorite list 1"),
                new FavoriteListDTO("favorite list 2"),
                new FavoriteListDTO("favorite list 3"),
            };


            List<IFavoriteList> FavoriteList = new List<IFavoriteList>() {
                new FavoriteList("favorite list 1"),
                new FavoriteList("favorite list 2"),
                new FavoriteList("favorite list 3"),
            };

            IUser userMock = new UserMock(FavoriteList);
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock(favoriteListDtos);
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);

            //act
            IReadOnlyList<IFavoriteList> result = favoriteListService.GetUserFavoriteLists();


            //Assert
            Assert.Equal(3, result.Count);
            Assert.Contains(result, fl => fl.name == "favorite list 1");
            Assert.Contains(result, fl => fl.name == "favorite list 2");
            Assert.Contains(result, fl => fl.name == "favorite list 3");

        }

        [Fact]
        public void GetUserFavoriteListThisReturnEmptyArray()
        {
            //Arrange
            List<FavoriteListDTO> favoriteListDtos = new List<FavoriteListDTO>();
            List<IFavoriteList> FavoriteList = new List<IFavoriteList>();

            IUser userMock = new UserMock(FavoriteList);
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock(favoriteListDtos);
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);

            //act
            IReadOnlyList<IFavoriteList> result = favoriteListService.GetUserFavoriteLists();

            //Assert
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void AddSongToFavoriteListWithNullSongThisThrowArgumentException()
        {
            //Arrange
            IUser userMock = new UserMock();
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock();
            IFavoriteList favoriteListMock = new FavoriteListMock();
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);

            //act
            Action act = () => favoriteListService.AddSongToFavoriteList(null, favoriteListMock);

            //Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Song is null", ex.Message);
        }

        [Fact]
        public void AddSongToFavoriteListWithNullFavoriteListThisThrowArgumentException()
        {
            //Arrange
            IUser userMock = new UserMock();
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock();
            IFavoriteList favoriteListMock = new FavoriteListMock();
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);

            //act
            Action act = () => favoriteListService.AddSongToFavoriteList(new Song("test"), null);

            //Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Favorite list is null", ex.Message);
        }

        [Fact]
        public void AddSongToFavoriteListThisFalseEnRerturnAFailureServiceStatusResultThatSongAlreadyInTheList()
        {
            //Arrange
            IUser userMock = new UserMock();
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock();
            IFavoriteList favoriteListMock = new FavoriteListMock("My favorite list", false);
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);

            //act
            ServiceStatusResult result = favoriteListService.AddSongToFavoriteList(new Song("name"), favoriteListMock);

            //Assert
            Assert.Equal("Info", result.messageTitle);
            Assert.Equal($"Song has already been added to {favoriteListMock.name} list, select another list!", result.messageText);
            Assert.False(result.isSuccess);
        }

        [Fact]
        public void AddSongToFavoriteListThisThatAddedSuccesAndRerturnSuccesServiceStatusResult()
        {
            //Arrange
            IUser userMock = new UserMock();
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock(true);
            IFavoriteList favoriteListMock = new FavoriteListMock(true);
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);

            //act
            ServiceStatusResult result = favoriteListService.AddSongToFavoriteList(new Song("name"), favoriteListMock);

            //Assert
            Assert.True(result.isSuccess);
        }

        [Fact]
        public void AddSongToFavoriteListThisAddSongToFavoriteListInToDatabaseReturnFalse()
        {
            //Arrange
            IUser userMock = new UserMock();
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock(false);
            IFavoriteList favoriteListMock = new FavoriteListMock(true);
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);

            //act
            ServiceStatusResult result = favoriteListService.AddSongToFavoriteList(new Song("name"), favoriteListMock);

            //Assert
            Assert.False(result.isSuccess);
            Assert.Equal("Error",result.messageTitle);
            Assert.Equal("Can't not add song into favorite list in database", result.messageText);
        }

        [Fact]
        public void RemoveSongInFavoriteListWithNullSongAndThrowArgumentException()
        {
            //Arrange
            IUser userMock = new UserMock();
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock();
            IFavoriteList favoriteListMock = new FavoriteListMock();
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);


            //act
            Action act = () => favoriteListService.RemoveSongInFavoriteList(null, favoriteListMock);

            //Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Song is null", ex.Message);
        }

        [Fact]
        public void RemoveSongInFavoriteListWithNullFavoriteListAndThrowArgumentException()
        {
            //Arrange
            IUser userMock = new UserMock();
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock();
            IFavoriteList favoriteListMock = new FavoriteListMock();
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);

            //Act
            Action act = () => favoriteListService.RemoveSongInFavoriteList(new Song("test"), null) ;

            //Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Favorite list is null", ex.Message);
        }

        [Fact]
        public void RemoveSongInFavoriteListThatIsRemovedIsFalseAndReturnAFailureServiceStatusResult()
        {
            //Arrange
            IUser userMock = new UserMock();
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock();
            IFavoriteList favoriteListMock = new FavoriteListMock(false);
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);

            //act
            ServiceStatusResult result = favoriteListService.RemoveSongInFavoriteList(new Song("test"), favoriteListMock);

            //assert
            Assert.False(result.isSuccess);
            Assert.Equal("Error",result.messageTitle);
            Assert.Equal("Removed song does not exist in the favorite list", result.messageText);
        }

        [Fact]
        public void RemoveSongInFavoriteListThatIsRemovedInDatabseReturnFalse()
        {
            //Arrange
            IUser userMock = new UserMock();
            IFavoriteRepository favoriteRepositoryMock = new FavoriteListRepositoryMock(false);
            IFavoriteList favoriteListMock = new FavoriteListMock(true);
            FavoriteListService favoriteListService = new FavoriteListService(userMock, favoriteRepositoryMock);

            //act
            ServiceStatusResult result = favoriteListService.RemoveSongInFavoriteList(new Song("test"), favoriteListMock);

            //assert
            Assert.False(result.isSuccess);
            Assert.Equal("Error", result.messageTitle);
            Assert.Equal("Can't remove song in favorite list in databse", result.messageText);
        }
    }
}
