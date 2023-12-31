﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FPT_BOOKSHOP.Models;
using FPT_BOOKSHOP.Data;
using Microsoft.EntityFrameworkCore;

namespace FPT_BOOKSHOP.Areas.Customer.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _db;

    public HomeController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        var ds = _db.Books.Include(b => b.category).ToList();
        return View(ds);
    }

    public IActionResult Detail(int id)
    {
        var book = _db.Books.Find(id);
        if (book == null)
        {
            return RedirectToAction("Index");
        }

        return View(book);
    }

    [HttpGet]
    public IActionResult Index(string keyword)
    {
        if (_db.Books == null)
        {
            return NotFound();
        }
        var books = from b in _db.Books select b;
        if (!string.IsNullOrEmpty(keyword))
        {
            books = books.Where(s => s.status == 1 && s.name!.Contains(keyword));
        }

        return View(books.ToList());
    }

    public IActionResult Help()
    {
        return View();
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}
