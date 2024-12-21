using KuaforProjesi.Data; 
using KuaforProjesi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KuaforProjesi.Controllers
{
    public class RandevuController : Controller
    {
        private readonly DataContext _context;

        public RandevuController(DataContext context)
        {
            _context = context;
        }

        // GET: Randevu
        public async Task<IActionResult> Randevu()
        {
            var viewModel = new RandevuViewModel
            {
                Calisanlar = await _context.Calisanlarimiz.ToListAsync(),
                Islemler = await _context.Islemler.ToListAsync()
            };

            if (viewModel.Islemler == null || !viewModel.Islemler.Any())
            {
                // Islemler tablosunda veri yoksa, bir hata mesajı veya boş liste dönebilirsiniz
                ModelState.AddModelError("", "İşlem verisi bulunamadı.");
            }
            return View(viewModel); // View'a viewModel gönder
        }

        // POST: Randevu
        [HttpPost]
        public async Task<IActionResult> Randevu(RandevuViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Modelden yeni randevu nesnesi oluştur
                var randevu = new Randevu
                {
                    calisanAdi = viewModel.calisanAdi,  // Modelden gelen çalışan ID
                    IslemAdi = viewModel.IslemAdi,      // Modelden gelen işlem ID
                    Tarih = viewModel.Tarih,          // Modelden gelen tarih
                    Saat = viewModel.Saat             // Modelden gelen saat
                };

                // Veritabanına ekle
                _context.Randevular.Add(randevu);  // 'viewModel' kullanıldı
                await _context.SaveChangesAsync(); // Değişiklikleri kaydet

                // Başarılı işlem sonrası yönlendirme
                return RedirectToAction("Index", "Home");
            }

            // Eğer model geçerli değilse, formu tekrar göster
            return View(viewModel);  // Geçerli değilse aynı sayfayı yeniden yükle
        }

        [HttpGet]
        public async Task<JsonResult> GetCalisanlarByIslem(int islemId)
        {
            var calisanlar = await _context.Calisanlarimiz
                .Where(c => c.Islemler.Any(i => i.IslemId == islemId))
                .Select(c => new { c.CalisanId, c.Ad, c.Soyad })
                .ToListAsync();
            return Json(calisanlar);
        }

     

    }
}
