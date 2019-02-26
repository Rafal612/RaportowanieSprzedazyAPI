using RaportowanieSprzedazy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RaportowanieSprzedazy.DTO
{
    public class ProjektDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Nazwa { get; set; }

        public IList<int> PracownicyDtoId { get; set; }
        public IList<int> AnkietyDtoId { get; set; }
    }
}