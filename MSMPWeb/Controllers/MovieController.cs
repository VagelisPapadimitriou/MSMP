using Microsoft.AspNetCore.Mvc;
using MSMP.DataAccess.Repositories.IRepositories;
using MSMP.Models;

namespace MSMPWeb.Controllers
{
    public class MovieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MovieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Movie> allMovies = _unitOfWork.Movie.GetAll().ToList();

            return View(allMovies);
        }






        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Movie> allMovies = _unitOfWork.Movie.GetAll().ToList();
            return Json(new { data = allMovies });

        }

        #endregion





    }
}
