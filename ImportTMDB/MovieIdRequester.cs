using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using MSMP.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using ImportTMDB.Models;

namespace ImportTMDB
{

    public class MovieIdRequester
    {
        private List<TmdbMovieIdentifier> _tmdbMovieIds;

        public async Task<IEnumerable<TmdbMovieIdentifier>> GetTmdbMovieIdsFromJsonUrl()
        {

            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Format the date as "MM_DD_YYYY"
            string dateString = currentDate.ToString("MM_dd_yyyy");

            // The URL to download the file with all the ids
            string url = $"https://files.tmdb.org/p/exports/movie_ids_{dateString}.json.gz";

            try
            {
                // Download the compressed file
                byte[] compressedData;

                using (var httpClient = new HttpClient())
                {
                    compressedData = await httpClient.GetByteArrayAsync(url);
                }

                // Decompress the file and read its contents
                using (var compressedStream = new MemoryStream(compressedData))
                using (var gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                using (var reader = new StreamReader(gzipStream))
                {
                    _tmdbMovieIds = new List<TmdbMovieIdentifier>();    // Initialize or clear the list

                    // Read each line (each line represents a JSON object)
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        // Parse the JSON object in the line
                        var deserializedMovieId = JsonConvert.DeserializeObject<TmdbMovieIdentifier>(line);

                        // Add the deserialized Movie object to the list of movies
                        _tmdbMovieIds.Add(deserializedMovieId);
                    }

                    return _tmdbMovieIds;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while parsing JSON: {ex.Message}");
                return null; // Return null to indicate an error
            }
        }

    }
    public class TmdbMovieIdentifier
    {
        public int Id { get; set; }
    }


    public class MovieRequester
    {
        public async Task<IEnumerable<TmdbMovie>> GetTmdbMovieDetails(IEnumerable<TmdbMovieIdentifier> tmdbMovieIds)
        {
            List<TmdbMovie> tmdbMovies = new List<TmdbMovie>();

            foreach (var movie_id in tmdbMovieIds)
            {
                using (var client = new HttpClient())
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
                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        var responseBody = await response.Content.ReadAsStringAsync();

                        // Deserialize the response body into a TmdbMovie object
                        var tmdbMovie = JsonConvert.DeserializeObject<TmdbMovie>(responseBody);

                        // Add the deserialized tmdbMovie object to the list
                        tmdbMovies.Add(tmdbMovie);
                    }
                }
            }
            return tmdbMovies;

        }
    }


}
