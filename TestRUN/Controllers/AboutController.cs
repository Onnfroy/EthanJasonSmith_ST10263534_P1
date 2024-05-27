using Microsoft.AspNetCore.Mvc;

namespace CLDV6211_POE_P1.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View("/Views/About/About.cshtml");
        }
    }
}
