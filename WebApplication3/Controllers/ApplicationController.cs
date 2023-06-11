using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication3.Controllers
{
        public class ApplicationController : Controller
        {
            private readonly JobPortalDb _dbContext;

            public ApplicationController(JobPortalDb dbContext)
            {
                _dbContext = dbContext;
            }

            // Başvuruları listeleme
            public IActionResult Index()
            {
                List<ApplicationController> applications = _dbContext.Applications.ToList();
                return View(applications);
            }

            // Başvuru detayları
            public IActionResult Details(int id)
            {
                ApplicationController application = _dbContext.Applications.FirstOrDefault(a => a.Id == id);
                if (application == null)
                {
                    return NotFound();
                }
                return View(application);
            }

            // Yeni başvuru oluşturma formu
            public IActionResult Create()
            {
                return View();
            }

            // Yeni başvuruyu veritabanına kaydetme
            [HttpPost]
            public IActionResult Create(Applications application)
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Applications.Add(application);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(application);
            }

            // Başvuru düzenleme formu
            public IActionResult Edit(int id)
            {
                ApplicationController application = _dbContext.Applications.FirstOrDefault(a => a.Id == id);
                if (application == null)
                {
                    return NotFound();
                }
                return View(application);
            }

            // Başvuruyu güncelleme
            [HttpPost]
            public IActionResult Edit(Applications application)
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Applications.Update(application);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(application);
            }

            // Başvuru silme formu
            public IActionResult Delete(int id)
            {
                ApplicationController application = _dbContext.Applications.FirstOrDefault(a => a.Id == id);
                if (application == null)
                {
                    return NotFound();
                }
                return View(application);
            }

            // Başvuruyu silme
            [HttpPost]
            public IActionResult DeleteConfirmed(int id)
            {
                ApplicationController application = _dbContext.Applications.FirstOrDefault(a => a.Id == id);
                if (application == null)
                {
                    return NotFound();
                }
                _dbContext.Applications.Remove(application);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }

}
