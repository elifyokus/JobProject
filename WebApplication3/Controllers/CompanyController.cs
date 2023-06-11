using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class CompanyController : Controller
    {
        // Şirketlerin listeleneceği sayfa
        public IActionResult Index()
        {
            var companies = GetCompaniesFromDatabase();

            return View(companies);
        }

        // Şirket detaylarının gösterileceği sayfa
        public IActionResult Details(int id)
        {
            var company = GetCompanyByIdFromDatabase(id);

            return View(company);
        }

    }

}
