using System;
using drinki.BazaDanych;
using drinki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace drinki.Controllers;

public class OcenaController : Controller
{
    public ContextBazy BazaDanych;

    public OcenaController(ContextBazy bazaDanych)
    {
        BazaDanych = bazaDanych;
    }

    public IActionResult Index()
    {
        var oceny = BazaDanych.Oceny.Include(x => x.Drink).ToList();
        return View(oceny);
    }

    public IActionResult Create()
    {
        ViewBag.Drinki = new SelectList(BazaDanych.Drinki.ToList(), "DrinkId", "Nazwa");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Ocena ocena)
    {
        if (ModelState.IsValid)
        {
            BazaDanych.Oceny.Add(ocena);
            BazaDanych.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.Drinki = new SelectList(BazaDanych.Drinki.ToList(), "DrinkId", "Nazwa");
        return View(ocena);
    }
}
