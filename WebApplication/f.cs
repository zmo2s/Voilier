using Microsoft.AspNetCore.Mvc;

namespace WebApplication
{
    public class f : Controller
    {
        // GET : /
        public IActionResult Index()
        {
          
                return View("a.html");
            
        }
    }
}