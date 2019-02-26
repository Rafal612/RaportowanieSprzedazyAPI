using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("Pracownicy")]
        [Required]
        public IList<int> PracownicyDtoId { get; set; }
        public IList<Pracownik> Pracownicy { get; set; }
        [ForeignKey("Ankiety")]
        [Required]
        public IList<int> AnkietyDtoId { get; set; }
        public IList<Ankieta> Ankiety { get; set; }



    }
}