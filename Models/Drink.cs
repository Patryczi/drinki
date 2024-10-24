using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace drinki.Models;

public class Drink
{
    [ValidateNever]
    public int DrinkId { get; set; }
    [Required(ErrorMessage = "Nazwa jest wymagana.")]
    [MinLength(3, ErrorMessage = "Nazwa powinna mieć co najmniej 3 znaki")]
    public string Nazwa { get; set; }

    [Required(ErrorMessage = "Opis jest wymagany.")]
    public string Opis { get; set; }

    [Required(ErrorMessage = "Cena powinna być podana.")]
    public decimal Cena { get; set; }

    [ValidateNever]
    public int KategoriaId { get; set; }  // Klucz obcy
    
    [ValidateNever]
    public Kategoria Kategoria { get; set; }
}
