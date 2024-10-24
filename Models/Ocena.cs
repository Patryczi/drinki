using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace drinki.Models;

public class Ocena
{
    [ValidateNever]
    public int OcenaId { get; set; }

    [Range(1, 5, ErrorMessage = "Wartość musi być w zakresie od 1 do 5.")]
    public int Wartosc { get; set; }  // Zakres od 1 do 5

    [Required(ErrorMessage = "Komentarz jest wymagany")]
    [MinLength(3, ErrorMessage = "Komentarz powinien mieć co najmniej 3 znaki")]

    public string Komentarz { get; set; }
    
    [ValidateNever]
    public int DrinkId { get; set; }  // Klucz obcy
    
    [ValidateNever]
    public Drink Drink { get; set; }
}

