using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ImportTMDB
{

    // auti i klasi mou dimiourgei ena object typou MovieIdOnly me mono to Id pou to pernei apo to arxeio pou pernaei me to url apo controller

    public class MovieIdRequester
    {
        public async Task<List<MovieIdOnly>> GetMovieIdsFromJsonUrl(string url)
        {
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
                    List<MovieIdOnly> movieIds = new List<MovieIdOnly>();

                    // Read each line (each line represents a JSON object)
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        // Parse the JSON object in the line
                        var jsonObject = JsonConvert.DeserializeObject<MovieIdOnly>(line);

                        // Add the deserialized Movie object to the list of movies
                        movieIds.Add(jsonObject);
                    }

                    return movieIds;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while parsing JSON: {ex.Message}");
                return null; // Return null to indicate an error
            }
        }

    }
    public class MovieIdOnly
    {
        public int Id { get; set; }
    }


}
