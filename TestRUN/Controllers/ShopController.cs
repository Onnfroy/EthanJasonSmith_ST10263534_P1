using Microsoft.AspNetCore.Mvc;

namespace CLDV6211_POE_P1.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View("/Views/MyWork/Shop.cshtml");
        }
    }
}
