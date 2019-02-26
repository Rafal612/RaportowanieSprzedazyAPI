using RaportowanieSprzedazy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RaportowanieSprzedazy.DTO
{
    public class AnkietaDto
    {

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int Numer { get; set; }
        [Required]
        [ForeignKey("ProjektDto")]
        public int ProjektId { get; set; }
        [Required]
        public ProjektDto ProjektDto { get; set; }
    }
}