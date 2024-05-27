using CLDV_POE_P1.Models;
using CLDV6211_POE_P1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CLDV6211_POE_P1.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.UserTables.ToListAsync();
            return View(users);
        }

        public IActionResult Contactus()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> User(UserTable user)
        {
            if (ModelState.IsValid)
            {
                _context.UserTables.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult User()
        {
            UserTable model = new UserTable();
            return View(model);
        }
    }
}




