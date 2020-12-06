using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PhotoAlbum.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void When_Api_Is_Called_Return_Ok_Status_Code_And_Correct_Amount_Of_Photo_Albums()
        {
            var photos = GetSamplePhotos();
            var albums = GetSampleAlbums();


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

            };
        }

    }
}
