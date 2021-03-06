﻿using RaportowanieSprzedazy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RaportowanieSprzedazy.DTO
{
    public class OdpowiedzDto
    {
        public int Id { get; set; }
        [Required]
        public PytanieDto PytanieDto { get; set; }
        [Required]
        public PracownikDto PracownikDto { get; set; }
        public string TrescString { get; set; }
        public double TrescDouble { get; set; }
        public int TrescInt { get; set; }
        public bool TrescBool { get; set; }
    }
}