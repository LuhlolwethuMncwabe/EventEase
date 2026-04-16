using EventEase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventEase.Controllers
{
    // this handles general pages not database Create, read, update and delete (CRUD)
    public class HomeController : Controller
    {
        // The landing page  
        public IActionResult Index()
        {
            return View();
        }

        // The privacy page
        public IActionResult Privacy()
        {
            return View();
        }

        // these lines handle handle error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Pass error onfromation to the view 
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
