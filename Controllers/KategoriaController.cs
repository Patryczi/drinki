using System;
using drinki.BazaDanych;
using drinki.Models;
using Microsoft.AspNetCore.Mvc;

namespace drinki.Controllers;

public class KategoriaController : Controller
{
    public ContextBazy BazaDanych;

    public KategoriaController(ContextBazy bazaDanych)
    {
        BazaDanych = bazaDanych;
    }

    public IActionResult Index()
    {
        var kategorie = BazaDanych.Kategorie.ToList();
        return View(kategorie);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Kategoria kategoria)
    {
        if (ModelState.IsValid)
        {
            BazaDanych.Kategorie.Add(kategoria);
            BazaDanych.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(kategoria);
    }
}
