using KuaforProjesi.Data;
using KuaforProjesi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KuaforProjesi.Controllers
{  
    [Authorize]
    public class RandevuController : Controller
    {
        private readonly DataContext _context;

        public RandevuController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Randevu()
        {
            var viewModel = new RandevuViewModel
            {
                Islemler = _context.Islemler.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Randevu(RandevuViewModel model)
        {
            if (ModelState.IsValid)
            {
                var randevu = new Randevu
                {
                    IslemId = model.IslemId,
                    MusteriAdi = model.MusteriAdi,
                    Tarih = model.Tarih,
                    Saat = model.Saat,
                    calisanAdi = _context.Calisanlarimiz.FirstOrDefault(c => c.CalisanId == model.CalisanId)?.Ad,
                    IslemAdi = _context.Islemler.FirstOrDefault(i => i.IslemId == model.IslemId)?.IslemAdi
                };

                _context.Randevular.Add(randevu);
                _context.SaveChanges();
                return RedirectToAction("Randevu");
            }

            model.Islemler = _context.Islemler.ToList();
            return View(model);
        }

        [HttpGet]
        public JsonResult GetCalisanlarByIslem(int islemId)
        {
            var calisanlar = _context.IslemCalisanlar
                .Where(ic => ic.IslemId == islemId)
                .Select(ic => new { ic.Calisan.CalisanId, ic.Calisan.Ad, ic.Calisan.Soyad })
                .ToList();

            return Json(calisanlar);
        }

        [HttpGet]
        public IActionResult GetCalisanSaatleri(int calisanId, DateTime tarih)
        {
            var calisan = _context.Calisanlarimiz.FirstOrDefault(c => c.CalisanId == calisanId);
            if (calisan == null || string.IsNullOrEmpty(calisan.calismaSaati))
            {
                return Json(new List<object>());
            }

            // Çalışma saatlerini ayır
            var saatler = calisan.calismaSaati.Split('-').Select(int.Parse).ToList();
            
            var doluSaatler = _context.Randevular
                .Where(r => r.calisanAdi == calisan.Ad)
                .Select(r => r.Saat).ToList();

            var saatSecenekleri = Enumerable.Range(saatler[0], saatler[1] - saatler[0] + 1)
                .Select(saat => new
                {
                    Saat = saat,
                    Durum = doluSaatler.Contains(saat) ? "Dolu" : "Müsait"
                }).ToList();
            
            return Json(saatSecenekleri);
        }
    }
}
