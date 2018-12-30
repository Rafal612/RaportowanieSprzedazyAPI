using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RaportowanieSprzedazy.Models
{
    public class Pytanie
    {

        public int Id { get; set; }
        [Required]
        public RodzajPytania RodzajPytania { get; set; }
        [Required]
        [MaxLength(240)]
        public string Tresc { get; set; }
        [Required]
        public Ankieta Ankieta { get; set; }
        public IList<Odpowiedz> Odpowiedzi { get; set; }
        //public IList<Pracownik> Pracownicy{ get; set; }
        //TODO Do sprawdzanie realcja pytanie odpowiedz pracownik
    }
}