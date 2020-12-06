using Newtonsoft.Json;
using PhotoAlbumAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.Helpers
{
    public class ClientHelper : IClientHelper
    {
        private readonly Uri _photoAddress;
        private readonly Uri _albumAddress;
        public ClientHelper(Uri photoAddress, Uri albumAddress)
        {
            _photoAddress = photoAddress;
            _albumAddress = albumAddress;
        }

        public async Task<IEnumerable<T>> GetPhotoAlbums<T>()
        {
            var client = new HttpClient();
            var type = typeof(T);

            //smelly code..will definitely refactor this given more time
            client.BaseAddress = type == typeof(PhotoDTO) ? client.BaseAddress = _photoAddress : _albumAddress;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(client.BaseAddress);

            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(result);
            }

            return null;
        }
    }
}
