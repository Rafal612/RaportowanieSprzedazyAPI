using RaportowanieSprzedazy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RaportowanieSprzedazy.DTO
{
    public class PracownikDto
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Imie { get; set; }
        [MaxLength(60)]
        public string DrugieImie { get; set; }
        [Required]
        [MaxLength(120)]
        public string Nazwisko { get; set; }
        public Stanowisko Stanowisko { get; set; }
        public IList<Projekt> Projekty { get; set; }
    }
}