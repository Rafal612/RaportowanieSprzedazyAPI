﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RaportowanieSprzedazy.Models
{
    public class Ankieta
    {

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int Numer { get; set; }
        [Required]
        public Projekt Projekt { get; set; }
    }
}