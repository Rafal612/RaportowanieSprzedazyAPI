using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RaportowanieSprzedazy.DTO
{
    public class RodzajPytaniaDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Nazwa { get; set; }
    }
}