using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class CategoryController : Controller
    {
        private readonly JobPortalDb _dbContext;

        public CategoryController(JobPortalDb dbContext)
        {
            _dbContext = dbContext;
        }

        // Kategorilerin listeleneceği sayfa
        public IActionResult Index()
        {
            List<CategoryController> categories = _dbContext.Category.ToList();

            // Kategorileri view dosyasına gönderme
            return View(categories);
        }

        // Kategori detaylarının gösterileceği sayfa
        public IActionResult Details(int id)
        {
            CategoryController category = _dbContext.Category.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            // Kategoriyi view dosyasına gönderme
            return View(category);
        }
        // Yeni kategori oluşturma formu
        public IActionResult Create()
        {
            return View();
        }

        // Yeni kategoriyi veritabanına kaydetme
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Category.Add(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // Kategori düzenleme formu
        public IActionResult Edit(int id)
        {
            CategoryController category = _dbContext.Category.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // Kategoriyi güncelleme
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // Kategori silme formu
        public IActionResult Delete(int id)
        {
            CategoryController category = _dbContext.Category.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // Kategoriyi silme
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            CategoryController category = _dbContext.Category.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

}
