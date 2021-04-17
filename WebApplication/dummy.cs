using Microsoft.AspNetCore.Mvc;

namespace WebApplication
{
    public class dummy : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Redirect( Url.Content( "~/a.html" ) );
        }
    }
}