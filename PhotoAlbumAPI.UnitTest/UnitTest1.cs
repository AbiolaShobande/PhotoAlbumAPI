using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PhotoAlbumAPI.Controllers;
using PhotoAlbumAPI.DTO;
using PhotoAlbumAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace PhotoAlbumAPI.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task When_Api_Is_Called_Return_Ok_Status_Code_And_Correct_Amount_Of_Photo_Albums()
        {
            var photos = GetSamplePhotos();
            var albums = GetSampleAlbums();

            var mockClientHelper = new Mock<IClientHelper>();
            mockClientHelper.Setup(ch => ch.GetPhotoAlbums<PhotoDTO>()).ReturnsAsync(photos);
            mockClientHelper.Setup(ch => ch.GetPhotoAlbums<AlbumDTO>()).ReturnsAsync(albums);

            var controller = new PhotoAlbumController(mockClientHelper.Object);
            var sut = await controller.GetPhotoAlbum();

            var x = (sut.Result as ActionResult);
        }

        [TestMethod]
        public void When_There_Are_No_Photo_Albums_Return_Ok_Status_Code_With_No_Content()
        {

        }

        [TestMethod]
        public void When_Filtered_By_User_Return_Only_PhotoAlbums_Related_To_User()
        {

        }

        [TestMethod]
        public void When_Filtered_By_User_That_Doesnt_Exist_Return_Not_Found()
        {

        }

        private List<PhotoDTO> GetSamplePhotos()
        {
            return new List<PhotoDTO>
            {
                new PhotoDTO{AlbumId = 3, Id = 1, Title= "Test Photo 1", Url = new Uri("https://test.com"), ThumbnailUrl = new Uri("https://test2.com")},
                new PhotoDTO{AlbumId = 1, Id = 2, Title= "Test Photo 2", Url = new Uri("https://test.com"), ThumbnailUrl = new Uri("https://test2.com")},
                new PhotoDTO{AlbumId = 3, Id = 3, Title= "Test Photo 3", Url = new Uri("https://test.com"), ThumbnailUrl = new Uri("https://test2.com")},
                new PhotoDTO{AlbumId = 1, Id = 4, Title= "Test Photo 4", Url = new Uri("https://test.com"), ThumbnailUrl = new Uri("https://test2.com")},
                new PhotoDTO{AlbumId = 2, Id = 5, Title= "Test Photo 5", Url = new Uri("https://test.com"), ThumbnailUrl = new Uri("https://test2.com")}
            };
        }

        private List<AlbumDTO> GetSampleAlbums ()
        {
            return new List<AlbumDTO>
            {
                new AlbumDTO{Id = 1, Title = "Test Album 1", UserId = 4 },
                new AlbumDTO{Id = 2, Title = "Test Album 2", UserId = 5 },
                new AlbumDTO{Id = 3, Title = "Test Album 3", UserId = 6 },
            };
        }

    }
}
