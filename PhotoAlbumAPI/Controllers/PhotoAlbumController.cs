using Microsoft.AspNetCore.Mvc;
using PhotoAlbumAPI.DTO;
using PhotoAlbumAPI.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.Controllers
{
    [Route("api/photoAlbum")]
    [ApiController]
    public class PhotoAlbumController : Controller
    {
        private readonly IClientHelper _clientHelper;
        public PhotoAlbumController(IClientHelper clientHelper)
        {
            _clientHelper = clientHelper;
        }

        [HttpGet]
        public async Task <IActionResult> GetPhotoAlbum()
        {
            var photoAlbum = await FetchPhotoAlbums();
            return Ok(photoAlbum);
        }
 
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserPhotoAlbum(int userId)
        {
            var photoAlbum = await FetchPhotoAlbums();
            var userPhotoAlbum = photoAlbum.Where(pa => pa.Album.UserId == userId);

            if(!userPhotoAlbum.Any())
            {
                return NotFound();
            }

            return Ok(userPhotoAlbum);
        }

        private async Task<List<PhotoAlbumDTO>> FetchPhotoAlbums()
        {
            var albums = await _clientHelper.GetPhotoAlbums<AlbumDTO>();
            var photos = await _clientHelper.GetPhotoAlbums<PhotoDTO>();

            var photoAlbums = from photo in photos
                              join album in albums
                              on photo.AlbumId equals album.Id
                              select new { Photo = photo, Album = album };

            return photoAlbums.Select(x => new PhotoAlbumDTO { Album = x.Album, Photo = x.Photo}).ToList();             
        }
    }
}
