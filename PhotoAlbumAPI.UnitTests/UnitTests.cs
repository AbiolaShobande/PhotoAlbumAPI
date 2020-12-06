using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PhotoAlbumAPI.Controllers;
using PhotoAlbumAPI.DTO;
using PhotoAlbumAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public async Task When_Api_Is_Called_Return_Ok_Status_Code_With_Photo_Album_List()
        {
            //Arrange
            var photoAlbumController = CreateController();

            //Act
            var okObjectResult = await photoAlbumController.GetPhotoAlbum();

            //Assert
            okObjectResult.Should().NotBeNull();
            okObjectResult.Should().BeOfType<OkObjectResult>();
            var photoAlbumDTOFromController = (OkObjectResult) okObjectResult;
            photoAlbumDTOFromController.Value.Should().BeOfType<List<PhotoAlbumDTO>>();
        }

        [TestMethod]
        public async Task When_Api_Is_Called_And_Filtered_By_UserId_Return_Photo_Albums_Related_To_That_User()
        {
            //Arrange
            var photoAlbumController = CreateController();
            var userId = 5;

            //Act
            var okObjectResult = await photoAlbumController.GetUserPhotoAlbum(userId);

            //Assert
            okObjectResult.Should().NotBeNull();
            okObjectResult.Should().BeOfType<OkObjectResult>();
            var photoAlbumDTOFromController = ((OkObjectResult)okObjectResult).Value;

            var photoAlbums = (IEnumerable<PhotoAlbumDTO>)photoAlbumDTOFromController;

            foreach(var photoAlbum in photoAlbums)
            {
                photoAlbum.Album.UserId.Should().Be(userId);
            }
        }

        [TestMethod]
        public async Task When_Api_Is_Called_And_Filtered_By_Unknown_UserId_Return_Not_Found()
        {
            //Arrange
            var photoAlbumController = CreateController();
            var userId = 55;

            //Act
            var notFoundResult = await photoAlbumController.GetUserPhotoAlbum(userId);

            //Assert
            notFoundResult.Should().NotBeNull();
            notFoundResult.Should().BeOfType<NotFoundResult>();
        }

        private PhotoAlbumController CreateController()
        {
            var photos = GetSamplePhotos();
            var albums = GetSampleAlbums();

            var mockClientHelper = new Mock<IClientHelper>();
            mockClientHelper.Setup(ch => ch.GetPhotoAlbums<PhotoDTO>()).ReturnsAsync(photos);
            mockClientHelper.Setup(ch => ch.GetPhotoAlbums<AlbumDTO>()).ReturnsAsync(albums);

            return new PhotoAlbumController(mockClientHelper.Object);
        }

        private List<PhotoDTO> GetSamplePhotos()
        {
            return new List<PhotoDTO> 
            { 
                new PhotoDTO{AlbumId = 3, Id = 1, Title = "Test Photo 1", ThumbnailUrl = new Uri("http://www.test.com"), Url = new Uri("http://www.test.com")},
                new PhotoDTO{AlbumId = 1, Id = 1, Title = "Test Photo 2", ThumbnailUrl = new Uri("http://www.test.com"), Url = new Uri("http://www.test.com")},
                new PhotoDTO{AlbumId = 2, Id = 1, Title = "Test Photo 3", ThumbnailUrl = new Uri("http://www.test.com"), Url = new Uri("http://www.test.com")},
                new PhotoDTO{AlbumId = 3, Id = 1, Title = "Test Photo 4", ThumbnailUrl = new Uri("http://www.test.com"), Url = new Uri("http://www.test.com")},
                new PhotoDTO{AlbumId = 1, Id = 1, Title = "Test Photo 5", ThumbnailUrl = new Uri("http://www.test.com"), Url = new Uri("http://www.test.com")}
            };
        }

        private List <AlbumDTO> GetSampleAlbums()
        {
            return new List<AlbumDTO>
            {
                new AlbumDTO{ Id = 1, Title = "Test Album 1", UserId = 4},
                new AlbumDTO{ Id = 2, Title = "Test Album 2", UserId = 5},
                new AlbumDTO{ Id = 3, Title = "Test Album 3", UserId = 6},
            };
        }
    }
}
