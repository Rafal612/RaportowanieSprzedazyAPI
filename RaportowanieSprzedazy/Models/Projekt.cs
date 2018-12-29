using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RaportowanieSprzedazy.Models
{
    public class Projekt
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Nazwa { get; set; }

        public IList<Pracownik> Pracownicy { get; set; }
        public IList<Ankieta> Ankiety { get; set; }



    }
}