using Microsoft.AspNetCore.Mvc;
using Photos.Services.Data;

namespace Photos.Controllers
{
    public class AppController : Controller
    {
        private readonly IPhotoRepository photoRepository;

        public AppController(IPhotoRepository photoRepository)
        {
            this.photoRepository = photoRepository;
        }
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Contact()
        {
            photoRepository.PrintRepoType();
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}