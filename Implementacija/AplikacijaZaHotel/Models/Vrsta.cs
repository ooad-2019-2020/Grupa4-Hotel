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

        public Vrsta()
        {

        }
        public Vrsta(int Id1, string Naziv1, float Cijena1, bool Balkon1, bool Dostupnost1, int Kapacitet1)
        {
            Id = Id1;
            Naziv = Naziv1;
            Cijena = Cijena1;
            Balkon = Balkon1;
            Dostupnost = Dostupnost1;
            Kapacitet = Kapacitet1;
        }
    }

    
}
