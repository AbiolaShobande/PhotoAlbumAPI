using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.Helpers
{
    public interface IClientHelper
    {
        Task<IEnumerable<T>> GetPhotoAlbums<T>();
    }
}
