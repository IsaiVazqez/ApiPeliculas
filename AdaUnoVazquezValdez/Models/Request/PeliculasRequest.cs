﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaUnoVazquezValdez.Models.Request
{
    public class PeliculasRequest
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Puntuacion { get; set; }
        public string Rating { get; set; }
        public DateTime AñoDePublicacion { get; set; }
    }
}
