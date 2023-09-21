using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspCMS.Models;
using aspCMS.Data;
using Microsoft.AspNetCore.Identity;
using aspCMS.Auth;
using aspCMS.Models;
namespace aspCMS.Controllers;

public class AdminController : Controller
{
    private readonly SignInManager<AdminUsers> _signInManager;

    public AdminController(SignInManager<AdminUsers> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(AdminInfo model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                // Redirect to a successful login page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
        }

        return View(model);
    }
}
