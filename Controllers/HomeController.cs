using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Include için gerekli
using KuaforProjesi.Data; // Veritabanı modellerine erişim
using System.Linq;

namespace KuaforProjesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // İşlemleri ve çalışanları veritabanından çekiyoruz
            var hizmetler = _context.Islemler.ToList();
            var calisanlar = _context.Calisanlarimiz.Include(c => c.IslemCalisanlar).ToList();

            // Verileri View'e taşıyoruz
            ViewBag.Hizmetler = hizmetler;
            ViewBag.Calisanlar = calisanlar;

            return View();
        }
    }
}
