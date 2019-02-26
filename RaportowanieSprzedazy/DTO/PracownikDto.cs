using RaportowanieSprzedazy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("Stanowisko")]
        [Required]
        public int StanowiskoId { get; set; }
        [ForeignKey("Projekty")]
        [Required]
        public IList<int> ProjektyId { get; set; }

    }
}