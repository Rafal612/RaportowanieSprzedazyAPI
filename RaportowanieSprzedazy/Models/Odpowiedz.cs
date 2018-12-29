using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RaportowanieSprzedazy.Models
{
    public class Odpowiedz
    {

        public int Id { get; set; }
        public IList<Pytanie> Pytania { get; set; }
        public Pracownik Pracownik { get; set; }
        [Required]
        [MaxLength(240)]
        public string Tresc { get; set; }
    }
}