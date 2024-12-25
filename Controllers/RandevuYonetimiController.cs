using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Include için gerekli


namespace KuaforProjesi.Controllers
{
    public class RandevuYonetimiController : Controller
    {
        public IActionResult RandevuYonetimi()
        {
            return View();
        }
    }
}
