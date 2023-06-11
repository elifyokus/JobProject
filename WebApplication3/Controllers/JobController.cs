using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class JobController : Controller
    {
        public class JobsController : Controller
    {
        private readonly JobPortalDb _dbContext;

        public JobsController(JobPortalDb dbContext)
        {
            _dbContext = dbContext;
        }
        // İş ilanlarının listeleneceği sayfa
        public IActionResult Index()
        {
            List<Job> jobs = _dbContext.Jobs.ToList();

            return View(jobs);
        }

        // İş ilanı detaylarının gösterileceği sayfa
        public IActionResult Details(int id)
        {
            Job job = _dbContext.Jobs.FirstOrDefault(j => j.Id == id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }
        public IActionResult Create()
        {
            return View();
        }

        // Yeni iş ilanını veritabanına kaydetme
        [HttpPost]
        public IActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Jobs.Add(job);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // İş ilanını düzenleme formu
        public IActionResult Edit(int id)
        {
            Job job = _dbContext.Jobs.FirstOrDefault(j => j.Id == id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // İş ilanını güncelleme
        [HttpPost]
        public IActionResult Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Jobs.Update(job);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // İş ilanını silme formu
        public IActionResult Delete(int id)
        {
            Job job = _dbContext.Jobs.FirstOrDefault(j => j.Id == id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // İş ilanını silme
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            Job job = _dbContext.Jobs.FirstOrDefault(j => j.Id == id);
            if (job == null)
            {
                return NotFound();
            }
            _dbContext.Jobs.Remove(job);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
