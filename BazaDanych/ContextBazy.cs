using System;
using drinki.Models;
using Microsoft.EntityFrameworkCore;

namespace drinki.BazaDanych;

public class ContextBazy(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<Drink> Drinki { get; set; }
    
    public DbSet<Kategoria> Kategorie { get; set; }
    
    public DbSet<Ocena> Oceny { get; set; }
    
    public DbSet<Skladnik> Skladniki { get; set; }
}
