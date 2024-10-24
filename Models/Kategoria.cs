using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace drinki.Models;

public class Kategoria
{
    [ValidateNever]
    public int KategoriaId { get; set; }

    [Required(ErrorMessage = "Nazwa jest wymagana.")]
    [MinLength(3, ErrorMessage = "Nazwa powinna mieć co najmniej 3 znaki")]
    public string Nazwa { get; set; }

    [ValidateNever]
    public ICollection<Drink> Drinki { get; set; }
}
