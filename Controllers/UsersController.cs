using Authentication.Data;
using Authentication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
          _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {

            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var checkUserLogin = _context.Users.Where(User => user.Name == User.Name && user.Email == User.Email);
            if (checkUserLogin.Any())
            {
                return View("Index");
            }
           
            ViewBag.Error = "Invalid email or password";
            return View(user);
        }
        [HttpGet]
        public IActionResult ActiveState()
        {
            var ActiveUsers = _context.Users.Where(user => user.IsActive == false).ToList();
            return View(ActiveUsers);
        }

     
        public IActionResult Active(Guid id)
        {
            var user = _context.Users.Find(id);
            user.IsActive = true;
            _context.SaveChanges();
          
            return RedirectToAction(nameof(ActiveState));
           

        }

    }
    }

