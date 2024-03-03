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
            List<Movie> movies = _unitOfWork.Movie.GetAll().ToList();
            return View(movies);

        }
    }
}
