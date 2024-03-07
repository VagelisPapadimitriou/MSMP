using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;
using System.IO.Compression;

namespace ImportTMDB
{
    public class TMDBRequester
    {
        private readonly HttpClient _httpClient;

        public TMDBRequester()
        {
            _httpClient = new HttpClient();
        }

      


        public async Task<IEnumerable<string>> GetMovieDetails(IEnumerable<int> movieIds)
        {
            List<string> movieDetailsList = new List<string>();

            foreach (var movie_id in movieIds)
            {

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://api.themoviedb.org/3/movie/{movie_id}?language=en-US"),
                    Headers =
                {
                    { "accept", "application/json" },
                    { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxN2QzYmJjMzk4ZjQyN2E2OTQzNjY0YjlhZmIxOGZiZCIsInN1YiI6IjY1ZDY2MWRlYzVjMWVmMDE3ZDhiMGMyMCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.qxubBLtBeigAN_v4Wx06niX5DqWZ8MZhRdQrs4xmRWM" },
                },
                };
                using (var response = await _httpClient.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();
                    movieDetailsList.Add(responseBody);
                }
            }
           return movieDetailsList;
        }







    }
}

