using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspCMS.Models;
using aspCMS.Data;
using HtmlAgilityPack;
using aspCMS.Repository.UsersRepository;

namespace aspCMS.Controllers;

public class AdminController : Controller
{
    private readonly IUsersRepository usersRepo;

    public AdminController(IUsersRepository _userRepo)
    {
        usersRepo = _userRepo;
    }

    public IActionResult Login()

    {

        return View();

    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
