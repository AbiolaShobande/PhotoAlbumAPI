using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.DTO
{
    public class PhotoAlbumDTO
    {
        public PhotoDTO Photo { get; set; }
        public AlbumDTO Album { get; set; }
    }
}
