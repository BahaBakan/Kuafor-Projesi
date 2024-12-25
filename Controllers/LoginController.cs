using KuaforProjesi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace KuaforProjesi.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly DataContext _context; // DbContext eklendi

        public LoginController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, DataContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context; // DbContext inject edildi
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                TempData["Basarisiz"] = "E-mail ve şifre alanları boş olamaz.";
                return RedirectToAction("Login");
            }

            // Identity kontrolü
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (result.Succeeded)
                {
                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return RedirectToAction("AdminPaneli", "AdminPaneli");
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            // Registers tablosundan kontrol
            var registerUser = _context.Registers.FirstOrDefault(r => r.Eposta == email && r.Sifre == password);
            if (registerUser != null)
            {
                // Kullanıcı bulundu, giriş başarılı
                TempData["Basarili"] = "Giriş başarılı!";
                return RedirectToAction("Index", "Home");
            }

            TempData["Basarisiz"] = "E-mail veya şifre yanlış.";
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
