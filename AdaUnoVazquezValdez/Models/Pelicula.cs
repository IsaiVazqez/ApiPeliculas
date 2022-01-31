using System;
using System.Collections.Generic;

#nullable disable

namespace AdaUnoVazquezValdez.Models
{
    public partial class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Puntuacion { get; set; }
        public string Rating { get; set; }
        public DateTime AñoDePublicacion { get; set; }
    }
}
