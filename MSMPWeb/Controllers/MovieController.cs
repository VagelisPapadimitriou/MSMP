using Microsoft.AspNetCore.Mvc;
using MSMP.DataAccess.Repositories.IRepositories;
using MSMP.Models;
using ImportTMDB;

namespace MSMPWeb.Controllers
{
    public class MovieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MovieIdRequester _movieIdRequester;
        private readonly TMDBRequester _tmdbRequester;
        public MovieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _movieIdRequester = new MovieIdRequester(); // thelw na to allaksw na to valw ston ctor kai meta na to perasw sto DI sto program
            _tmdbRequester = new TMDBRequester();
        }

        public IActionResult Index()
        {
            List<Movie> allMovies = _unitOfWork.Movie.GetAll().ToList();

            return View(allMovies);
        }

        public async Task<IActionResult> GetAll()
        {
            try
            {
                // Get the current date
                DateTime currentDate = DateTime.Now;

                // Format the date as "MM_DD_YYYY"
                string dateString = currentDate.ToString("MM_dd_yyyy");

                // Construct the URL with the formatted date
                string url = $"https://files.tmdb.org/p/exports/movie_ids_{dateString}.json.gz";

                // Get the movie IDs from the URL
                List<MovieIdOnly> movieIds = await _movieIdRequester.GetMovieIdsFromJsonUrl(url);

                // The list of movie IDs
                return Json(new { movieIds });  // auto to ekana apla gia na ta dw. Na ta xrisimopoiisw gia ta details? vlepw


                //IEnumerable<int> movieIds = await _movieIdRequester.GetAllMovieIds();
                //IEnumerable<string> movieDetails = await _tmdbRequester.GetMovieDetails(movieIds);

                //return Json(new { movieDetails });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        //public IActionResult GetAll()
        //{
        //    List<Movie> allMovies = _unitOfWork.Movie.GetAll().ToList();
        //    return Json(new { data = allMovies });

        //}

    }
}
