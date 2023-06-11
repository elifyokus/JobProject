using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {
        private readonly JobPortalDb _dbContext;

        public UserController(JobPortalDb dbContext)
        {
            _dbContext = dbContext;
        }
        // Kullanıcı giriş sayfası
        public IActionResult Login()
        {
            // Giriş sayfasını gösterin
            return View();
        }

        // Kullanıcı kayıt sayfası
        public IActionResult Register()
        {
            return View();
        }
        // Kullanıcıları listeleme
        public IActionResult Index()
        {
            List<User> users = _dbContext.User.ToList();
            return View(users);
        }

        // Kullanıcı detayları
        public IActionResult Details(int id)
        {
            User user = _dbContext.User.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // Yeni kullanıcı oluşturma formu
        public IActionResult Create()
        {
            return View();
        }

        // Yeni kullanıcıyı veritabanına kaydetme
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _dbContext.User.Add(user);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // Kullanıcı düzenleme formu
        public IActionResult Edit(int id)
        {
            User user = _dbContext.User.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // Kullanıcıyı güncelleme
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _dbContext.User.Update(user);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // Kullanıcı silme formu
        public IActionResult Delete(int id)
        {
            User user = _dbContext.User.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // Kullanıcıyı silme
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            User user = _dbContext.User.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
