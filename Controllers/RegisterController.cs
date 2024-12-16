using KuaforProjesi.Data;
using Microsoft.AspNetCore.Mvc;

namespace KuaforProjesi.Controllers{
public class RegisterController : Controller
{ 
    private readonly DataContext _context;
   public RegisterController(DataContext context)
   {
    _context=context;
   }
public IActionResult Register()
{
    return View();
}  

[HttpPost]
public async Task<IActionResult> Register(Register model)
{
    _context.Registers.Add(model);
    await _context.SaveChangesAsync();
    return RedirectToAction("Index","Home");
} 

}

}