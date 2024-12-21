using KuaforProjesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KuaforProjesi.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (string.IsNullOrEmpty(model.email) || string.IsNullOrEmpty(model.password))
            {
                TempData["Basarisiz"] = "E-mail ve şifre alanları boş olamaz.";
                return RedirectToAction("Login", "Login");
            }

            // Kullanıcının veritabanında olup olmadığını kontrol et
            var user = await _context.Registers
                .FirstOrDefaultAsync(u => u.Eposta == model.email && u.Sifre == model.password);

            if (user != null)
            {
                TempData["Basarili"] = "Başarıyla giriş yaptınız";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Basarisiz"] = "E-mail veya şifre yanlış.";
                return RedirectToAction("Login", "Login");
            }
        }
    }
}
