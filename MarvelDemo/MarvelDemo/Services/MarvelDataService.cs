using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MarvelDemo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MarvelDemo.Services
{
    public class MarvelDataService : IMarvelDataService
    {
        // TODO: Add your Marvel Developer Account keys
        const string _API_PRIVATE_KEY = "e4c7e6f3829adaa09677323a8716226bbf4c619e";
        const string _API_PUBLIC_KEY = "10de83b086c87909f37ef4ca92d7c554";

        readonly IHashService _hashService;

        public MarvelDataService(IHashService hashService)
        {
            _hashService = hashService;
        }

        public async Task<IEnumerable<Comic>> GetComicsBySeries(int seriesId, string orderBy = null)
        {
            var ts = Guid.NewGuid().ToString();
            var hash = _hashService.CreateMd5Hash(ts + _API_PRIVATE_KEY + _API_PUBLIC_KEY);

            if (string.IsNullOrWhiteSpace(orderBy))
                orderBy = "issueNumber";

            var url =
                $@"http://gateway.marvel.com/v1/public/series/{seriesId}/comics?orderBy={orderBy}&apikey={_API_PUBLIC_KEY}&hash={hash}&ts={ts}";
            
            var client = new HttpClient();
            var response = await client.GetStringAsync(url);
            
            var responseObject = JObject.Parse(response);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<Comic>>(responseObject["data"]["results"].ToString()));
        }
    }
}
