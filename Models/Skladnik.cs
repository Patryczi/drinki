using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace drinki.Models;

public class Skladnik
{
    [ValidateNever]
    public int SkladnikId { get; set; }
    [Required(ErrorMessage = "Nazwa jest wymagana.")]
    [MinLength(3, ErrorMessage = "Nazwa powinna mieć co najmniej 3 znaki")]
    public string Nazwa { get; set; }
    
    
    [ValidateNever]
    public int DrinkId { get; set; }  // Klucz obcy
    
    [ValidateNever]
    public Drink Drink { get; set; }
}
