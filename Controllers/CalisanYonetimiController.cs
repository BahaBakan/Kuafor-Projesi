using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Include için gerekli


namespace KuaforProjesi.Controllers
{
    public class CalisanYonetimiController : Controller
    {
        public IActionResult CalisanYonetimi()
        {
            return View();
        }
    }
}
