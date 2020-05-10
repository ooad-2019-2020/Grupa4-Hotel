using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacijaZaHotel.Models
{
    public class Vrsta
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }
        public bool Balkon { get; set; }
        public bool Dostupnost { get; set; }
        public int Kapacitet { get; set; }
    }
}
