using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Include için gerekli
using KuaforProjesi.Data;

namespace KuaforProjesi.Controllers
{
    public class CalisanYonetimiController : Controller
    {   
        private readonly DataContext _context; 

        public CalisanYonetimiController(DataContext context)
        {
            _context = context;
        }

        public IActionResult CalisanYonetimi()
        { 
            var calisanlarListesi = _context.Calisanlarimiz.ToList(); 
            return View(calisanlarListesi);
        }

        [HttpPost]
        public IActionResult Ekle(Calisanlarimiz yeniCalisan)
        {
            if (ModelState.IsValid)
            {
                _context.Calisanlarimiz.Add(yeniCalisan);
                _context.SaveChanges();
                return RedirectToAction("CalisanYonetimi");
            }

            return View("CalisanYonetimi", _context.Calisanlarimiz.ToList());
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            var calisan = _context.Calisanlarimiz.Find(id);
            if (calisan != null)
            {
                _context.Calisanlarimiz.Remove(calisan);
                _context.SaveChanges();
            }
            return RedirectToAction("CalisanYonetimi");
        }

        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            var calisan = _context.Calisanlarimiz.Find(id);
            if (calisan == null)
            {
                return NotFound();
            }
            return View(calisan);
        }

        [HttpPost]
        public IActionResult Guncelle(Calisanlarimiz guncellenenCalisan)
        {
            if (ModelState.IsValid)
            {
                _context.Calisanlarimiz.Update(guncellenenCalisan);
                _context.SaveChanges();
                return RedirectToAction("CalisanYonetimi");
            }
            return View(guncellenenCalisan);
        }
    }
}