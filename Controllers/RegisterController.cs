using KuaforProjesi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KuaforProjesi.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı nesnesi oluştur
                var user = new IdentityUser
                {
                    UserName = model.Ad,
                    Email = model.Eposta
                };

                // Kullanıcıyı oluştur
                var result = await _userManager.CreateAsync(user, model.Sifre);
                if (result.Succeeded)
                {
                    // Customer rolü mevcut değilse oluştur
                    if (!await _roleManager.RoleExistsAsync("Customer"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Customer"));
                    }

                    // Kullanıcıyı Customer rolüne ata
                    await _userManager.AddToRoleAsync(user, "Customer");
                    
                    TempData["Basarili"] = "Kayıt başarılı! Şimdi giriş yapabilirsiniz.";
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    // Hataları modele ekle
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }
    }
}
