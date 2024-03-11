using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;
using System.IO.Compression;
using MSMP.Models;
using ImportTMDB.Models;

namespace ImportTMDB
{
    public class TMDBRequester
    {
        public async Task<IEnumerable<TmdbMovie>> GetTmdbMovieDetails()
        {
            var movieIdRequester = new MovieIdRequester();
            var tmdbMovieIds = await movieIdRequester.GetTmdbMovieIdsFromJsonUrl();

            var movieRequester = new MovieRequester();
            var tmdbMovies = await movieRequester.GetTmdbMovieDetails(tmdbMovieIds);

            return tmdbMovies;
        }










    }
}

