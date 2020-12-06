using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.DTO
{
    public class PhotoDTO
    {
        public int AlbumId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public Uri Url { get; set; }
        public Uri ThumbnailUrl { get; set; }
    }
}
