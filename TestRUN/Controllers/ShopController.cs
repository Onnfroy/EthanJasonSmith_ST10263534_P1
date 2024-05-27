using Microsoft.AspNetCore.Mvc;
using CLDV6211_POE_P1.Models;
using System.Linq;
using CLDV_POE_P1.Models;

namespace CLDV6211_POE_P1.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Shop()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
    }
}
