using System;
using drinki.BazaDanych;
using drinki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace drinki.Controllers;

public class SkladnikController : Controller
{
    public ContextBazy BazaDanych;

    public SkladnikController(ContextBazy bazaDanych)
    {
        BazaDanych = bazaDanych;
    }

    public IActionResult Index(int? selectedDrinkId)
    {
        ViewBag.Drinki = new SelectList(BazaDanych.Drinki.ToList(), "DrinkId", "Nazwa");

        var skladniki = BazaDanych.Skladniki.Include(x => x.Drink).ToList();

        if (selectedDrinkId.HasValue)
        {
            skladniki = skladniki.Where(x => x.DrinkId == selectedDrinkId.Value).ToList();
        }

        return View(skladniki);
    }

    public IActionResult Create()
    {
        ViewBag.Drinki = new SelectList(BazaDanych.Drinki.ToList(), "DrinkId", "Nazwa");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Skladnik skladnik)
    {
        if (ModelState.IsValid)
        {
            BazaDanych.Skladniki.Add(skladnik);
            BazaDanych.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.Drinki = new SelectList(BazaDanych.Drinki.ToList(), "DrinkId", "Nazwa");
        return View(skladnik);
    }

    public IActionResult Edit(int id)
    {
        ViewBag.Drinki = new SelectList(BazaDanych.Drinki.ToList(), "DrinkId", "Nazwa");

        var skladnik = BazaDanych.Skladniki.Find(id);
        return View(skladnik);
    }

    [HttpPost]
    public IActionResult Edit(int id, Skladnik skladnik)
    {
        if (ModelState.IsValid)
        {
            Skladnik skladnik1 = BazaDanych.Skladniki.Find(id);
            skladnik1.DrinkId = skladnik.DrinkId;
            skladnik1.Nazwa = skladnik.Nazwa;
            BazaDanych.Update(skladnik1);
            BazaDanych.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.Drinki = new SelectList(BazaDanych.Drinki.ToList(), "DrinkId", "Nazwa");
        return View(skladnik);
    }
}
