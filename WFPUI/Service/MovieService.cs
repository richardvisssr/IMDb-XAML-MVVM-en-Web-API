using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using WFPUI.Model;

namespace WFPUI.Service
{
    public class MovieService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string ApiUrl = "https://localhost:7061/api/Movies/";

        private static Lazy<MovieService> _instance = new Lazy<MovieService>(() => new MovieService());

        private MovieService() { }

        public static MovieService Instance => _instance.Value;

        public async Task<bool> IsServerAvailableAsync()
        {
            try
            {
                var response = await client.GetAsync(ApiUrl);
                return response.IsSuccessStatusCode;
            }
            catch
            {
               
                return false;
            }
        }

        public async IAsyncEnumerable<MovieModel> GetMoviesAsync()
        {
            if (!await IsServerAvailableAsync())
            {
 
                yield break;
            }

            var response = await client.GetAsync(ApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var movies = JsonSerializer.Deserialize<List<MovieModel>>(await response.Content.ReadAsStringAsync());
                foreach (var movie in movies)
                {
                    yield return movie;
                }
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
