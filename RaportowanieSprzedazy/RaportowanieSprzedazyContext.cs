using RaportowanieSprzedazy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RaportowanieSprzedazy
{
    public class RaportowanieSprzedazyContext : DbContext
    {
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Projekt> Projekty{ get; set; }
        public DbSet<Ankieta> Ankiety { get; set; }
        public DbSet<Odpowiedz> Odpowiedzi { get; set; }


        public RaportowanieSprzedazyContext()
        {
            
        }
    }
}