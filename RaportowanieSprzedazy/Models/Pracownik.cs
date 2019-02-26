using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RaportowanieSprzedazy.Models
{
    public class Pracownik
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
        [ForeignKey("Stanowisko")]
        [Required]
        public int StanowiskoId { get; set; }
        public Stanowisko Stanowisko { get; set; }
        [ForeignKey("Projekty")]
        [Required]
        public virtual IList<int> ProjektyId { get; set; }
        public virtual IList<Projekt> Projekty { get; set; }

        //public IList<Odpowiedz> Odpowiedzi { get; set; }
        //public IList<Pytanie> Pytania { get; set; }

    }
}