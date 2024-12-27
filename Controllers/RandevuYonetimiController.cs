using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Include için gerekli
using KuaforProjesi.Data;

namespace KuaforProjesi.Controllers
{
    public class RandevuYonetimiController : Controller
    {   
        private readonly DataContext _context; 

        public RandevuYonetimiController(DataContext context)
        {
            _context = context;
        }

        public IActionResult RandevuYonetimi()
        { 
            var RandevularListesi = _context.Randevular.ToList(); 
            return View(RandevularListesi);
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            var randevu = _context.Randevular.Find(id);
            if (randevu != null)
            {
                _context.Randevular.Remove(randevu);
                _context.SaveChanges();
            }
            return RedirectToAction("RandevuYonetimi");
        }

        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            var randevu = _context.Randevular.Find(id);
            if (randevu == null)
            {
                return NotFound();
            }
            return View(randevu);
        }

        [HttpPost]
        public IActionResult Guncelle(Randevu guncellenenRandevu)
        {
            if (ModelState.IsValid)
            {
                _context.Randevular.Update(guncellenenRandevu);
                _context.SaveChanges();
                return RedirectToAction("RandevuYonetimi");
            }
            return View(guncellenenRandevu);
        }
    }
}