using CLDV_POE_P1.Models;
using CLDV6211_POE_P1.Extensions;
using CLDV6211_POE_P1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CLDV6211_POE_P1.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
            return View(cart);
        }

        public IActionResult AddToCart(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
                cart.AddProduct(product);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Shop", "Shop");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            if (cart != null)
            {
                cart.RemoveProduct(id);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }
    }
}
