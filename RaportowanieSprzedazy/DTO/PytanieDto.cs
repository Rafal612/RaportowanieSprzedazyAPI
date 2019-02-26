using RaportowanieSprzedazy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RaportowanieSprzedazy.DTO
{
    public class PytanieDto
    {

        public int Id { get; set; }
        [Required]
        public RodzajPytaniaDto RodzajPytaniaDto { get; set; }
        [Required]
        [MaxLength(240)]
        public string Tresc { get; set; }
        [Required]
        public AnkietaDto AnkietaDto { get; set; }
        public IList<OdpowiedzDto> OdpowiedziDto { get; set; }
    }
}