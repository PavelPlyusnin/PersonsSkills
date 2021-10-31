using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonsSkills.Models;
using System.Diagnostics;

namespace PersonsSkills.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository repository;

        public HomeController(Repository repository)
        {
            this.repository = repository;
        }

        private readonly ILogger<HomeController> _logger;

        public IActionResult Index()
        {
            var model = repository.GetPersons();
            return View(model);
        }

        public IActionResult Details(long? id)
        {
            if (id != null)
            {
                var person = repository.GetPersonById(id.Value);
                return View(person);
            }

            return NotFound();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
