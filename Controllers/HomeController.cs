﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspCMS.Models;
using aspCMS.Data;

namespace aspCMS.Controllers;

public class HomeController : Controller
{
    private readonly AppDBContext _db;

    public HomeController(AppDBContext db)
    {
        _db = db;
    }

    public IActionResult Index()

    {
        List<Post> postsList = _db.Posts.ToList();
        foreach (var post in postsList)
        {
            int length = post.Content.Length;
            if (length > 60)
            {
                length = 60;
            }
            post.Content = post.Content.Substring(0, length);

        }
        return View(postsList);

    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
