using Microsoft.AspNetCore.Mvc;
using MSMP.DataAccess.Repositories.IRepositories;
using MSMP.Models;
using ImportTMDB;

namespace MSMPWeb.Controllers
{
    public class MovieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TMDBRequester _tmdbRequester;
        public MovieController(IUnitOfWork unitOfWork, TMDBRequester tmdbRequester)
        {
            _unitOfWork = unitOfWork;
            _tmdbRequester = tmdbRequester;
        }

        public IActionResult Index()
        {
            List<Movie> allMovies = _unitOfWork.Movie.GetAll().ToList();

            return View(allMovies);
        }

        public async Task<IActionResult> GetAllTmdbMovies()
        {
            try
            {
                var tmdbMovies = await _tmdbRequester.GetTmdbMovieDetails();

                return Json(tmdbMovies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        public async Task<IActionResult> SaveMovie()
        {
            return null;
        }



    }
}
