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
                CalisanSaatleri = await _context.CalisanSaatler.ToListAsync(),
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
                    CalisanId = viewModel.CalisanId,  // Modelden gelen çalışan ID
                    IslemId = viewModel.IslemId,      // Modelden gelen işlem ID
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
    }
}
