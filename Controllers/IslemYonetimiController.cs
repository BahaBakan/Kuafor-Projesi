using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Include için gerekli
using KuaforProjesi.Data;

namespace KuaforProjesi.Controllers
{
    public class IslemYonetimiController : Controller
    {   
        private readonly DataContext _context; 

        public IslemYonetimiController(DataContext context)
        {
            _context = context;
        }

        public IActionResult IslemYonetimi()
        { 
            var IslemlerListesi = _context.Islemler.ToList(); 
            return View(IslemlerListesi);
        }

        [HttpPost]
        public IActionResult Ekle(Islem yeniIslem)
        {
            if (ModelState.IsValid)
            {
                _context.Islemler.Add(yeniIslem);
                _context.SaveChanges();
                return RedirectToAction("IslemYonetimi");
            }

            return View("IslemYonetimi", _context.Islemler.ToList());
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            var islem = _context.Islemler.Find(id);
            if (islem != null)
            {
                _context.Islemler.Remove(islem);
                _context.SaveChanges();
            }
            return RedirectToAction("IslemYonetimi");
        }

        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            var islem = _context.Islemler.Find(id);
            if (islem == null)
            {
                return NotFound();
            }
            return View(islem);
        }

        [HttpPost]
        public IActionResult Guncelle(Islem guncellenenIslem)
        {
            if (ModelState.IsValid)
            {
                _context.Islemler.Update(guncellenenIslem);
                _context.SaveChanges();
                return RedirectToAction("IslemYonetimi");
            }
            return View(guncellenenIslem);
        }
    }
}