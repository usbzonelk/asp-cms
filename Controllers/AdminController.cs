using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspCMS.Models;
using aspCMS.Data;
using Microsoft.AspNetCore.Identity;
using aspCMS.Auth;
using aspCMS.Services;

namespace aspCMS.Controllers;
public class AdminController : Controller
{
    private readonly SignInManager<AdminUsers> _signInManager;
    private readonly UserService _adminService;

    public AdminController(SignInManager<AdminUsers> signInManager, UserService adminService)
    {
        _signInManager = signInManager;
        _adminService = adminService;
    }

    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return RedirectToAction("Login");
        }

    }

    [HttpGet]
    public IActionResult Login()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(AdminInfo model)
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }
        else

        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
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

    public async Task<IActionResult> Register(AdminRegister model)
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            if (ModelState.IsValid)
            {
                var user = new AdminUsers
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };

                var result = await _adminService.CreateUserAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Sign in the user after registration if desired
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    // Redirect to a success page or the home page
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Admin");
    }

}
