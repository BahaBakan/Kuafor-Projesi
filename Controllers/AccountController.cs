using Microsoft.AspNetCore.Mvc;

namespace KuaforProjesi.Controllers{
public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

public IActionResult Register()
{
    return View();
} 

}

}