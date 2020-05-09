using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacijaZaHotel.Models
{
    public class Sadrzaj
    {
        public int Id { get; set; }
        public string Naziv { get; set; } 
        public float Cijena { get; set; }
        public bool Dostupnost { get; set; }
        public string Opis { get; set; }
    }
}
