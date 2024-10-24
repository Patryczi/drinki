using System;
using drinki.BazaDanych;
using drinki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace drinki.Controllers;

public class DrinkController : Controller
{
    public ContextBazy BazaDanych;

    public DrinkController(ContextBazy bazaDanych)
    {
        BazaDanych = bazaDanych;
    }

    public IActionResult Index()
    {
        var drunki = BazaDanych.Drinki.ToList();
        return View(drunki);
    }

    public IActionResult Create()
    {
        var kategorie = BazaDanych.Kategorie.ToList();

        if (kategorie != null && kategorie.Any())
        {
            ViewBag.Kategorie = new SelectList(kategorie, "KategoriaId", "Nazwa");
        }
        else
        {
            ViewBag.Kategorie = new SelectList(Enumerable.Empty<SelectListItem>());
        }

        return View();
    }

    [HttpPost]
    public IActionResult Create(Drink drink)
    {
        if (ModelState.IsValid)
        {
            BazaDanych.Drinki.Add(drink);
            BazaDanych.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.Kategorie = new SelectList(BazaDanych.Kategorie, "KategoriaId", "Nazwa");
        return View(drink);
    }

    public IActionResult Edit(int id)
    {
        ViewBag.Kategorie = new SelectList(BazaDanych.Kategorie, "KategoriaId", "Nazwa");
        var drink = BazaDanych.Drinki.Find(id);
        return View(drink);
    }

    [HttpPost]
    public IActionResult Edit(int id, Drink drink)
    {
        if (ModelState.IsValid)
        {
            Drink drink1 = BazaDanych.Drinki.Find(id);
            drink1.Opis = drink.Opis;
            drink1.Nazwa = drink.Nazwa;
            drink1.KategoriaId = drink.KategoriaId;
            BazaDanych.Update(drink1);
            BazaDanych.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.Kategorie = new SelectList(BazaDanych.Kategorie, "KategoriaId", "Nazwa");
        return View(drink);
    }

    public IActionResult Delete(int id)
    {
        var drink = BazaDanych.Drinki.Find(id);
        if (drink == null)
        {
            return NotFound();
        }
        return View(drink);
    }

    [HttpPost]
    public IActionResult DeleteDrink(Drink drink)
    {
        var drink1 = BazaDanych.Drinki.Find(drink.DrinkId);
        BazaDanych.Drinki.Remove(drink1);
        BazaDanych.SaveChanges();
        return RedirectToAction("Index");
    }
}

