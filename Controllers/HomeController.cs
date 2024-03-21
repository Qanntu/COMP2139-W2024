using COMP2139_Labs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using COMP2139_Labs.Data;

namespace COMP2139_Labs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        //add my
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Details() 
        {   
            return View();
        
        }

        [HttpGet]
        public IActionResult GeneralSearch(string searchType, string searchString)
        {
            if(searchType == "Project")
            {
                return RedirectToAction("Search", "Project", new { searchString, area = "ProjectManagement" });

            }
            else if (searchType == "Task"){
                //searching tasks
                int defaultProjectId = 1; //BAD!!!
                return RedirectToAction("Search", "Task", new {projectId = defaultProjectId, searchString, area = "ProjectManagement" });

            }
            return RedirectToAction("Index", "Home");

        }

        public IActionResult NotFound(int statusCode)
        {
            if(statusCode == 404)
            {
                return View("NotFound");
            }
            return View("Error");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}